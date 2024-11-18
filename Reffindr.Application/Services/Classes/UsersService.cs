using Reffindr.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
namespace Reffindr.Application.Services.Classes;

public class UsersService : IUsersService
{
    public UsersService()
    {

        
    }

    public int GetUserIdFromToken()
    {
        string authHeader = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();
        string userId = _tokenService.CleanToken(authHeader);

        return int.Parse(userId);
    }
}
