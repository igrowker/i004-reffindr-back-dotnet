using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IUsersRepository : IGenericRepository<User>
{
	Task<User> GetUserbyEmail(string email);
    Task<User> GetUserById(int userId);

}
