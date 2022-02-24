namespace Bet.API.Auth;
public static class UserExtensions
{
    public static string UserId(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
        return (claim != null) ? claim.Value : string.Empty;
    }
    public static string UserName(this IIdentity identity)
    {
        var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);
        return (claim != null) ? claim.Value : string.Empty;
    }
}