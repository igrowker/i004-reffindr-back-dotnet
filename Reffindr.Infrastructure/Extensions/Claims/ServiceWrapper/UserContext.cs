using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        ClaimsPrincipal userIdString = _httpContextAccessor.HttpContext?.User!;
        int userIdParsed = Convert.ToInt32(userIdString!);

        return userIdParsed;
    }
}
