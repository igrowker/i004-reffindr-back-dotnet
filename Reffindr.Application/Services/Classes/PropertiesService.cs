using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;


namespace Reffindr.Application.Services.Classes;

public class PropertiesService : IPropertiesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public PropertiesService
        (
             IUnitOfWork unitOfWork,
             IAuthService authService,

        )
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {

        Property propertyToRegister = propertyPostRequestDto.ToModel();
        propertyToRegister.TenantId = 
        Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToRegister, cancellationToken);
        await _unitOfWork.Complete(cancellationToken);

        //PropertyPostResponseDto propertyPostResponseDto = registeredProperty.ToResponse();

        return new PropertyPostResponseDto { };
    }


}
