using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IApplicationRepository : IGenericRepository<ApplicationModel>
    {
        Task<List<ApplicationModel>> GetApplicationsByUserIdAsync(int userId);
        Task<bool> ExistsAsync(int userId, int propertyId);
    }
}
