using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IUserTenantInfoRepository : IGenericRepository<UserTenantInfo>
    {
        public async Task<UserTenantInfo> GetTenantBy
    }
}
