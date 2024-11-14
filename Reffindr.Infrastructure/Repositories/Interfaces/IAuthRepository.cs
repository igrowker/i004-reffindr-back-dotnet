﻿using Reffindr.Domain.Models.User;

namespace Reffindr.Infrastructure.Repositories.Interfaces;

public interface IAuthRepository : IGenericRepository<User>
{
    Task<User> GetByEmail (User user);
    Task<bool> EmailExists(string email);
}
