using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IApplicationRepository : IGenericRepository<Application>
    {
        Task<List<Application>> GetApplicationsByUserIdAsync(int userId);
    }
}
