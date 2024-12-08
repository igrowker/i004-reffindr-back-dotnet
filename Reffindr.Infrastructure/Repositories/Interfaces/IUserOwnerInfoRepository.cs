using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Repositories.Interfaces
{
    public interface IUserOwnerInfoRepository : IGenericRepository<UserOwnerInfo>
    {
        Task<UserOwnerInfo> GetOwnerInfoByUserId(int userId);
    }
}
