using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class UsersRepository : GenericRepository<User> , IUsersRepository
{
    public UsersRepository(ApplicationDbContext options) : base(options)
    {
        
    }
	public async Task<User> GetUserbyEmail(string email)
	{
        User? userDB = await _dbSet.Where(x => x.Email == email && x.RoleId==2) 
            .FirstOrDefaultAsync();

        return userDB!;
	}

    public async Task<User> GetUserById(int userId)
    {
        User? userDB = await _dbSet.FindAsync(userId);

        return userDB!;
    }
}
