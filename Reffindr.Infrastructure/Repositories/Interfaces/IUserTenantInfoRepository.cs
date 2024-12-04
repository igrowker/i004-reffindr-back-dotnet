using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IUserTenantInfoRepository : IGenericRepository<UserTenantInfo>
{
    Task<UserTenantInfo> GetTenantByUserId(int userId);
}