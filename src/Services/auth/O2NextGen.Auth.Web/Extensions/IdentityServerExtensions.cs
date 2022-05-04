using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Auth.Web.Data;

namespace O2NextGen.Auth.Web.Extensions
{
    public static class IdentityServerExtensions
    {
        public static IServiceCollection AddConfiguredIdentityServer(this IServiceCollection services,
           IConfiguration configuration)
        {
            var builder = services.AddIdentityServer(options =>
            {
                //    options.Events.RaiseErrorEvents = true;
                //    options.Events.RaiseInformationEvents = true;
                //    options.Events.RaiseFailureEvents = true;
                //    options.Events.RaiseSuccessEvents = true;
            })
            // using in memory, but we could also get it, for example, from the database

            .AddDeveloperSigningCredential()
            .AddInMemoryPersistedGrants()
            // access to data regarding the user's identity
            .AddInMemoryIdentityResources(GetIdentityResources())
            // APIs that may be accessed
            .AddInMemoryApiResources(GetApis())
            // client applications that may access users data and APIs on the user's behalf
            .AddInMemoryClients(GetClients())
            // configures IdentityServer integration with ASP.NET Core Identity
            .AddAspNetIdentity<O2User>();

            // to avoid bombarding the db with checks, make use of cache
            //.AddInMemoryCaching();
            // more about EF integration:
            // - http://docs.identityserver.io/en/latest/quickstarts/7_entity_framework.html
            // - http://docs.identityserver.io/en/latest/reference/ef.html?highlight=dbcontext

            return services;
        }
        
        private static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var profile = new IdentityResources.Profile();
            profile.Required = true;
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                profile
            };
        }
        
        // private static IEnumerable<ApiResource> GetApis()
        // {
        //     var apiResource = new ApiResource("smalltalkapi", "smalltalkapi");
        //     apiResource.Scopes.First().Required = true;
        //     return new[]
        //     {
        //         apiResource
        //     };
        // }
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource("smalltalkapi", "smalltalkapi")
            };
        
        private static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "smalltalk_client_reactjs",
                    // AllowedGrantTypes = GrantTypes.Code,

                    //ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RequireClientSecret = false,
                    // RequireClientSecret=false,
                    RequireConsent = false,
                    // RequirePkce = true, 
                    RedirectUris = new[] {"http://localhost:3003/signin-oidc"},
                    AllowedCorsOrigins = new []{"http://localhost:3003"},
                    PostLogoutRedirectUris = new []{"http://localhost:3003/signout-oidc"},
                    
                    //RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "smalltalkapi",
                        //IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    AllowAccessTokensViaBrowser = true,
                    //AllowOfflineAccess = true,
                    //AccessTokenLifetime = 60,
                    //RefreshTokenExpiration = TokenExpiration.Sliding,
                    //RequireConsent = false
                }
            };
        }
    }
}