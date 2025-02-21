using Duende.IdentityServer.Models;

namespace Identity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile().AddToProvile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("scope1"),
            new ApiScope("scope2"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "ToDoWorksListMVC",
                ClientSecrets = { new Secret("secret".Sha256()) },
                    
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7005/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7005/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7005/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile"}
            },
        };

    private static IdentityResource AddToProvile(this IdentityResource identityResource)
    {
        identityResource.UserClaims.Add("email");
        return identityResource;
    }
}
