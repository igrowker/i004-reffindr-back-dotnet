using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;


namespace Reffindr.Application.Services.Classes;

public class PropertiesService : IPropertiesService
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertiesService
        (
             IUnitOfWork unitOfWork
        )
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken)
    {
        Property propertyToRegister = propertyPostRequestDto.ToModel();
        Property registeredProperty = await _unitOfWork.PropertiesRepository.Create(propertyToRegister, cancellationToken);
        await _unitOfWork.Complete(cancellationToken);

        //PropertyPostResponseDto propertyPostResponseDto = registeredProperty

        return new PropertyPostResponseDto { };
    }


}
