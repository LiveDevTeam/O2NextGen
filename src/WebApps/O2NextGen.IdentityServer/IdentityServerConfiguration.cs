using System;
using IdentityServer4;
using IdentityServer4.Models;

namespace O2NextGen.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        internal static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("API", "SERVERAPI");
        }

        internal static IEnumerable<ApiScope> GetApiScope()
        {
            yield return new ApiScope("API");
        }

        internal static IEnumerable<Client> GetClients()
        {
            yield return new Client() { ClientName = "client.pfrcenter.blazor",
                RequireClientSecret = false,
                RequireConsent = false,
                RequirePkce = true,
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.Address,
                     IdentityServerConstants.StandardScopes.Email,
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile ,
                },
                RedirectUris =
                {
                     "https://localhost:7001/authentication/login-callback "
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:7001/authentication/logout-callback "
                }
            }; 
        }

        internal static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Address();
            yield return new IdentityResources.Profile ();
            yield return new IdentityResources.Email();
        }
    }
}

