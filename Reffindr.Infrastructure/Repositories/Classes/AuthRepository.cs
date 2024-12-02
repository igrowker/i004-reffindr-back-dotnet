using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class AuthRepository : GenericRepository<User>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext options) : base(options)
    {
        
    }

    public async Task<User> GetByEmail(User user)
    {
        User? userDataInDb = await _dbSet.FirstOrDefaultAsync(x => x.Email == user.Email);

        return userDataInDb!;
    }

    public async Task<bool> EmailExists(string email)
    {

        bool exists = await _dbSet.AnyAsync(x => x.Email == email);

        return exists;
    }
}
