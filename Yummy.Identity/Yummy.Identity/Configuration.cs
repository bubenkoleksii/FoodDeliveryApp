using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Yummy.Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new("YummyWebAPI", "Web API")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiResource> ApiResources = new List<ApiResource>
    {
        new("YummyWebAPI", "Web API", new []
        {
            JwtClaimTypes.Name,  
            JwtClaimTypes.Role
        })
        {
            Scopes = {"YummyWebAPI"}
        }
    };

    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client
        {
            ClientId = "YummyClient",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            RequireClientSecret = false,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "YummyWebAPI"
            }
        }
    };

    public static string RootUserEmail = "admin4yk@gmail.com";
}