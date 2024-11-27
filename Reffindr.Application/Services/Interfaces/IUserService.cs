using Reffindr.Shared.DTOs.Response.Property;

namespace Reffindr.Application.Services.Interfaces;

public interface IUserService
{
    Task<List<PropertyGetResponseDto>> GetOwnerPropertiesAsync();
}
