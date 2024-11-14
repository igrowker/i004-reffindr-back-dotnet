using Reffindr.Domain.Models.User;

namespace Reffindr.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateJWT(User user);
}