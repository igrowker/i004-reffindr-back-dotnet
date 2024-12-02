using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.Enum;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Classes;

public class PropertiesService : IPropertiesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IUserContext _userContext;
    private readonly IImageService _imageService;
    private readonly INotificationService _NotifyService;

    public PropertiesService
        (
             IUnitOfWork unitOfWork,
             IAuthService authService,
             IUserContext userContext,
             IImageService imageService,
			 INotificationService notifyService

		)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
        _userContext = userContext;
        _imageService = imageService;
        _NotifyService = notifyService;
    }

    public async Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync()
    {
        int userOwnerId = _userContext.GetUserId();
        List<Property>? ownerProperties = await _unitOfWork.PropertiesRepository.GetOwnerProperties(userOwnerId);

        List<PropertyGetResponseDto>? ownerPropertiesResponse = ownerProperties!.Select(x => x.ToResponse()).ToList();
        return ownerPropertiesResponse;
    }

    public async Task<Result<IEnumerable<PropertyGetResponseDto>>> GetPropertiesAsync(PropertyFilterDto filter)
    {
        int userId = _userContext.GetUserId();

        // Validar los filtros, utilizaré fluent validation
        // var validationResult = new PropertyFilterDtoValidator().Validate(filter);

        var properties = await _unitOfWork.PropertiesRepository.GetPropertiesAsync(filter, userId);

        IEnumerable<PropertyGetResponseDto> propertyDtos = properties.Select(p => p.ToResponse());

        return Result<IEnumerable<PropertyGetResponseDto>>.Success(propertyDtos);
    }


    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto,  CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

		Property propertyToCreate = propertyPostRequestDto.ToModel();
        propertyToCreate.TenantId = userId;
        propertyToCreate.IsDeleted = true;


        if (propertyPostRequestDto.Images != null)
        {
            var imageUrls = await _imageService.UploadImagesAsync(propertyPostRequestDto.Images, cancellationToken);

            propertyToCreate.Images = imageUrls.Select(url => new Image
            {
                ImageUrl = url
            }).ToList();
        }

        Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToCreate, cancellationToken);


		await _unitOfWork.Complete(cancellationToken);

        await _NotifyService.AddNotificationToUser(propertyPostRequestDto.OwnerEmail, registeredProperty.Id, NotificationType.Application, cancellationToken);


        PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToPostResponse();

        return propertyPostResponseDto;
    }
}
