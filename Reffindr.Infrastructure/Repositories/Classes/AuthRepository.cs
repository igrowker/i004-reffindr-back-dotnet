using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class AuthRepository : GenericRepository<User>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext options) : base(options)
    {
        
    }
}
