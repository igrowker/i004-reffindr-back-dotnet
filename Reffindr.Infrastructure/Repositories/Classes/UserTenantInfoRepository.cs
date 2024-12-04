using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class UserTenantInfoRepository : GenericRepository<UserTenantInfo>, IUserTenantInfoRepository
{
    public UserTenantInfoRepository(ApplicationDbContext options) : base(options)
    {
    }

    public async Task<UserTenantInfo> GetTenantByUserId(int userId)
    {
        UserTenantInfo? userTenantInfoDB = await _dbSet.Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        return userTenantInfoDB!;
    }
}