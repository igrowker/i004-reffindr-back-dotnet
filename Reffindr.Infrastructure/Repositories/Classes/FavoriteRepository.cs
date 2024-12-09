using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using System.Threading;

namespace Reffindr.Infrastructure.Repositories.Classes
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        private readonly IPropertiesRepository _propertiesRepository;

        public FavoriteRepository(ApplicationDbContext options, IPropertiesRepository propertiesRepository) : base(options)
        {
            _propertiesRepository = propertiesRepository;
        }

        public async Task<int> GetFavoriteByUserAndProperty(int userId, int propertyId)
        {
            // Verificar si ya está en favoritos y devolver el id del favorito
            var favoriteId = await _dbSet
                .Where(fp => fp.UserId == userId && fp.PropertyId == propertyId)
                .Select(fp => fp.Id)
                .FirstOrDefaultAsync();

            return favoriteId;
        }

        public async Task<List<Property>> GetFavoritesByUser(int userId)
        {
            return await _dbSet
            .Where(fp => fp.UserId == userId)
            .Include(fp => fp.Property)
            .Select(fp => fp.Property!)
            .ToListAsync();
        }
    }
}
