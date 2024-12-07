using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class UserOwnerInfoRepository : GenericRepository<UserOwnerInfo>, IUserOwnerInfoRepository
{
    public UserOwnerInfoRepository(ApplicationDbContext options) : base(options)
    {
    }

    public async Task<UserOwnerInfo> GetOwnerInfoByUserId(int userId)
    {
        UserOwnerInfo? userOwnerInfoDb = await _dbSet.Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        return userOwnerInfoDb!;
    }
}

