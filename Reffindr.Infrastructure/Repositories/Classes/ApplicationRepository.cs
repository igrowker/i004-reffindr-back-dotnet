using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;
using System.Threading;

namespace Reffindr.Infrastructure.Repositories.Classes
{
    public class ApplicationRepository : GenericRepository<ApplicationModel>, IApplicationRepository
    {

        public ApplicationRepository(ApplicationDbContext options) : base(options)
        {
        }

        public async Task<List<ApplicationModel>> GetApplicationsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .Include(a => a.Property)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int userId, int propertyId)
        {
            return await _dbSet.AnyAsync(a =>
                    a.UserId == userId &&
                    a.PropertyId == propertyId &&
                    !a.IsDeleted);
        }
    }
}
