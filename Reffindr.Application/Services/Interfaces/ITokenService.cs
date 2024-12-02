using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateJWT(User user);
    string CleanToken(string token);
    string DecodeToken(string token);
}
