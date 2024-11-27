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

        IEnumerable<PropertyGetResponseDto> propertyDtos = properties.Select(p => p.ToResponse());

        return Result<IEnumerable<PropertyGetResponseDto>>.Success(propertyDtos);
    }


    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, string ownerEmail, CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

		Property propertyToCreate = propertyPostRequestDto.ToModel();
        propertyToCreate.TenantId = userId;
        propertyToCreate.IsDeleted = false; // CAMBIE A FALSE PARA PROBAR ENDPOINT DE GET PROPERTIES


		Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToCreate, cancellationToken);


		await _unitOfWork.Complete(cancellationToken);

        await _NotifService.AddNotificationToUser(ownerEmail, registeredProperty.Id, NotificationType.Application, cancellationToken);

        PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToResponse();

        return propertyPostResponseDto;
    }
}
