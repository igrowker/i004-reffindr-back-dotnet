using System.Security.Claims;

namespace Reffindr.Infrastructure.Extensions.Claims;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserIdByClaim(this ClaimsPrincipal user)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        int userIdParsed = int.Parse(userId!);

        return userIdParsed;
    }
}
