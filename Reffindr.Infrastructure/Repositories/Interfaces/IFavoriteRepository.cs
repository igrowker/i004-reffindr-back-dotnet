using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        Task<int> GetFavoriteByUserAndProperty(int userId, int propertyId);
        Task<List<Property>> GetFavoritesByUser(int userId);
    }
}
