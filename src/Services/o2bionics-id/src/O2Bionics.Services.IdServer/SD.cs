using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace O2Bionics.Services.IdServer
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope(name: "cgen.api", displayName: "Acces to CGen API")
        };

        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "cgen.api",
                    "profile"
                }
            },
            new Client()
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5003/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc" },
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "cgen.api",
                    "profile"
                }
            },
        };
    }
}