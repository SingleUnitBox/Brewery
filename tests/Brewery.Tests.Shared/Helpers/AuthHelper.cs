using Brewery.Infrastructure.Auth;

namespace Brewery.Tests.Shared.Helpers;

public static class AuthHelper
{
    private static readonly AuthManager AuthManager;

    static AuthHelper()
    {
        var options = OptionsHelper.GetOptions<AuthOptions>("auth");
        AuthManager = new AuthManager(options);
    }
    
    public static string GenerateToken(string userId, string role = null, 
        string audience = null, IDictionary<string, IEnumerable<string>> claims = null)
        => AuthManager.GenerateToken(userId, role, audience, claims).AccessToken;
}