using Reffindr.Shared.DTOs.Response.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task AddFavorite(int userId, int propertyId, CancellationToken cancellationToken);
        Task RemoveFavorite(int userId, int propertyId, CancellationToken cancellationToken);
        Task<List<PropertyGetResponseDto>> GetFavorites(int userId);
    }
}
