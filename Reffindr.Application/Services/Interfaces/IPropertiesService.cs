using Reffindr.Shared.DTOs.Filter;
using Reffindr.Shared.DTOs.Pagination;
using Reffindr.Shared.DTOs.Request.Property;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.Result;

namespace Reffindr.Application.Services.Interfaces;

public interface IPropertiesService
{
    Task<List<PropertyGetResponseDto>> GetPropertiesAsync(PropertyFilterDto filter, PaginationDto paginationDto);
    Task<PropertyPostResponseDto> PostPropertyAsync(PropertyPostRequestDto propertyPostRequestDto, CancellationToken cancellationToken);
    Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync();
    Task<PropertyGetResponseDto> GetPropertyAsync(int id);
    Task<List<PropertyGetResponseDto>> GetTenantAnnounceAsync();
    Task<PropertyPatchResponseDto> ConfirmProperty(PropertyPatchRequestDto propertyConfirmPatchRequestDto,
        CancellationToken cancellationToken);
    Task<PropertyDeleteResponseDto> DeletePropertyAsync(int id, CancellationToken cancellationToken);

}
