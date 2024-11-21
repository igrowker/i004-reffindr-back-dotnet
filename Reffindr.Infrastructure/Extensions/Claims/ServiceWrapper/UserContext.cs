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
        ClaimsPrincipal user = _httpContextAccessor.HttpContext?.User!;
        return user!.GetUserIdByClaim();
    }

    public int GetRoleId()
    {
        Claim? roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);

        return int.Parse(roleClaim!.Value);
    }
}
