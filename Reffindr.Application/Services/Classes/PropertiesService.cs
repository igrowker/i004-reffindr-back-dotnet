using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Pagination;
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

    //public async Task<List<PropertyGetResponseDto>> GetTenantAnnounceAsync()
    //{
    //    int userTenantId = _userContext.GetUserId();
    //    List<Property>? tenantAnnounces = await _unitOfWork.PropertiesRepository.GetTenantAnnounce(userTenantId);

    //    List<PropertyGetResponseDto>? tenantAnnouncesResponse = tenantAnnounces!.Select(x => x.ToResponse()).ToList();
    //    return tenantAnnouncesResponse;
    //}

    public async Task<List<PropertyGetResponseDto>> GetPropertiesAsync(PropertyFilterDto filter, PaginationDto paginationDto)
    {
        //int userId = _userContext.GetUserId();

        // Validar los filtros, utilizaré fluent validation
        // var validationResult = new PropertyFilterDtoValidator().Validate(filter);

        var properties = await _unitOfWork.PropertiesRepository.GetPropertiesAsync(filter);

        List<PropertyGetResponseDto> propertyDtos = properties.Select(x => x.ToResponse()).ToList();

        return propertyDtos;
    }

    public async Task<PropertyGetResponseDto> GetPropertyAsync(int id)
    {
        Property propertyInDb = await _unitOfWork.PropertiesRepository.GetById(id);
        PropertyGetResponseDto propertyResponse = propertyInDb.ToResponse();

        return propertyResponse;
    }

    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        Property propertyToCreate = propertyPostRequestDto.ToModel();
        propertyToCreate.TenantId = userId;
        propertyToCreate.IsDeleted = false;


        if (propertyPostRequestDto.Images != null)
        {
            List<string> imageUrls = await _imageService.UploadImagesAsync(propertyPostRequestDto.Images, cancellationToken);
            Image listImagesUpload = new Image
            {
                CreatedAt = DateTime.UtcNow,
                ImageUrl = imageUrls
            };
            await _unitOfWork.ImageRepository.Create(listImagesUpload, cancellationToken);

            propertyToCreate.Images = listImagesUpload;
        }

        Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToCreate, cancellationToken);

        //propertyToCreate.NotificationId = notificationToOwner.PropertyId;
        //await _unitOfWork.PropertiesRepository.Update(registeredProperty.Id, registeredProperty);
        await _unitOfWork.Complete(cancellationToken);

        await _NotifyService.AddNotificationToUser(propertyPostRequestDto.OwnerEmail, registeredProperty.Id, NotificationType.Application, cancellationToken);

        PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToPostResponse();

        return propertyPostResponseDto;
    }




}
