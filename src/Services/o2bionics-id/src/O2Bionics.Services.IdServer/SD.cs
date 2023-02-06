using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace O2Bionics.Services.IdServer
{
    public static class SD
    {
        public static Dictionary<string, string> GetUrls(IConfiguration configuration)
        {
            var urls = new Dictionary<string, string>();
            urls.Add("PfrMvcUrl",
                Environment.GetEnvironmentVariable("Urls:PfrMvcUrl") ??
                configuration.GetValue<string>("Urls:PfrMvcUrl"));
            urls.Add("IdPortalMvcUrl",
                Environment.GetEnvironmentVariable("Urls:IdPortalMvcUrl") ??
                configuration.GetValue<string>("Urls:IdPortalMvcUrl"));


            Console.WriteLine(" ========================= CONFIG IDServer ========================== ");
            foreach (var item in urls)
            {
                Console.WriteLine($"key={item.Key}   value={item.Value}");
            }

            Console.WriteLine(" ================= END SETTINGS ====================\r\n");
            return urls;
        }

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
            new ApiScope(name: "cgen.api", displayName: "Access to CGen API"),
            new ApiScope(name: "idportal.api", displayName: "Access to CGen API")
        };

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls)
        {
            return
                new List<Client>()
                {
                    new Client()
                    {
                        ClientId = "client",
                        ClientSecrets = {new Secret("secret".Sha256())},
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes =
                        {
                            "cgen.api",
                            "profile"
                        }
                    },
                    new Client()
                    {
                        ClientId = "idportal",
                        ClientSecrets = {new Secret("secret".Sha256())},
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris =
                        {
                            $"{clientUrls["IdPortalMvcUrl"]}/signin-oidc",
                            "https://localhost:5003/signin-oidc"
                        },
                        PostLogoutRedirectUris =
                        {
                            $"{clientUrls["IdPortalMvcUrl"]}/signout-callback-oidc",
                            "https://localhost:5003/signout-callback-oidc"
                        },
                        AllowedCorsOrigins =
                        {
                            $"{clientUrls["IdPortalMvcUrl"]}",
                            "https://localhost:5003"
                        },
                        AllowedScopes = new List<string>()
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "idportal.api",
                            "profile"
                        }
                    },
                    new Client()
                    {
                        ClientId = "mvc",
                        ClientSecrets = {new Secret("secret".Sha256())},
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris =
                        {
                            $"{clientUrls["PfrMvcUrl"]}/signin-oidc",
                            "https://localhost:5003/signin-oidc"
                        },
                        PostLogoutRedirectUris =
                        {
                            $"{clientUrls["PfrMvcUrl"]}/signout-callback-oidc",
                            "https://localhost:5003/signout-callback-oidc"
                        },
                        AllowedCorsOrigins =
                        {
                            $"{clientUrls["PfrMvcUrl"]}",
                            "https://localhost:5003"
                        },
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
}