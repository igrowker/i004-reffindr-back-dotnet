using Reffindr.Shared.DTOs.Response.Property;

namespace Reffindr.Application.Services.Interfaces;

public interface IFavoriteService
{
    Task AddFavorite(int propertyId, CancellationToken cancellationToken);
    Task RemoveFavorite(int propertyId, CancellationToken cancellationToken);
    Task<List<PropertyGetResponseDto>> GetFavorites();
}
