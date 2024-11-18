using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;
using System.Security.Claims;

namespace Reffindr.Application.Services.Interfaces;

public interface IPropertiesService
{
    Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken);
}
