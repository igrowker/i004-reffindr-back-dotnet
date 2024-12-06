using Reffindr.Domain.Models;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IApplicationRepository : IGenericRepository<ApplicationModel>
    {
        Task<List<ApplicationModel>> GetApplicationsByUserIdAsync(int userId);
        Task<List<ApplicationModel>> GetApplicationsByPropertyIdAsync(int propertyId);
        Task<List<ApplicationModel>> GetApplicationsSelectedCandidates(int propertyId);
        Task<bool> ExistsAsync(int userId, int propertyId);
        Task<ApplicationModel> GetApplicationCandidate(int candidateUserId, int propertyId);
        Task<ApplicationModel> GetUserToSelect(int userId);
    }
}
