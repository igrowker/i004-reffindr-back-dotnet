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
    private readonly INotificationService _NotifService;

    public PropertiesService
        (
             IUnitOfWork unitOfWork,
             IAuthService authService,
             IUserContext userContext,
			 INotificationService notifService

		)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
        _userContext = userContext;
		_NotifService = notifService;
    }

    public async Task<Result<IEnumerable<PropertyGetResponseDto>>> GetPropertiesAsync(PropertyFilterDto filter)
    {
        int userId = _userContext.GetUserId();

        // Validar los filtros, utilizaré fluent validation
        // var validationResult = new PropertyFilterDtoValidator().Validate(filter);

        var properties = await _unitOfWork.PropertiesRepository.GetPropertiesAsync(filter, userId);

        if (properties == null || !properties.Any())
        {
            return Result<IEnumerable<PropertyGetResponseDto>>.Failure("No properties found.");
        }

        IEnumerable<PropertyGetResponseDto> propertyDtos = properties.Select(p => new PropertyGetResponseDto
        {
            Id = p.Id,
            Title = p.Title,
            Address = p.Address,
            Description = p.Description,
            CountryName = p.Country?.CountryName ?? "N/A",
            StateName = p.State?.StateName ?? "N/A",
            Price = p.Price
        });

        return Result<IEnumerable<PropertyGetResponseDto>>.Success(propertyDtos);
    }


    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();
        string receiverEmail = propertyPostRequestDto.Email;


		Property propertyToCreate = propertyPostRequestDto.ToModel();
        propertyToCreate.TenantId = userId;
        propertyToCreate.IsDeleted = false; // CAMBIE A FALSE PARA PROBAR ENDPOINT DE GET PROPERTIES


		Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToCreate, cancellationToken);

        await _NotifService.AddNotificationToUser(receiverEmail, NotificationType.Application, cancellationToken);

		await _unitOfWork.Complete(cancellationToken);


        //PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToResponse();

        return new PropertyPostResponseDto { };
    }


}
