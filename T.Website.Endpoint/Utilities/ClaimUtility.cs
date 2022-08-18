using System.Security.Claims;

namespace OS.Website.EndPoint.Utilities;

public static class ClaimUtility
{
    public static string GetUserId(ClaimsPrincipal user)
    {
        var claimsIdentity = user.Identity as ClaimsIdentity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        return userId;
    }

}
