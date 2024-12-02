using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Interfaces;

public interface IPropertiesService
{
    Task<Result<IEnumerable<PropertyGetResponseDto>>> GetPropertiesAsync(PropertyFilterDto filter);
    Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken);
    Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync();
    
}
