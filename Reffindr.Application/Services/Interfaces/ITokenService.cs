using Reffindr.Domain.Models;

namespace Reffindr.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateJWT(User user);
}