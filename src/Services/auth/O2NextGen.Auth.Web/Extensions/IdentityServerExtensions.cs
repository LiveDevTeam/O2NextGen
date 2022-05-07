using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Auth.Web.Data;
using O2NextGen.Auth.Web.Services;

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
            .AddAspNetIdentity<O2User>()

            // to avoid bombarding the db with checks, make use of cache
            //.AddInMemoryCaching();
            // more about EF integration:
            // - http://docs.identityserver.io/en/latest/quickstarts/7_entity_framework.html
            // - http://docs.identityserver.io/en/latest/reference/ef.html?highlight=dbcontext
            
            .Services.AddTransient<IProfileService, ProfileService>();
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
                new ApiResource("smalltalkapi", "smalltalkapi"),
                new ApiResource("smalltalkapisignalr","smalltalkapisignalr")
            };
        
        private static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // React client
                new Client
                {
                    ClientId = "smalltalk_client_reactjs",
                    ClientName = "SmallTalk React App",
                    ClientUri = "http://localhost:3003",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RequireClientSecret = false,

                    RedirectUris =
                    {                        
                        "http://localhost:3003/signin-oidc",                        
                    },

                    PostLogoutRedirectUris = { "http://localhost:3003/signout-oidc" },
                    AllowedCorsOrigins = { "http://localhost:3003" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "smalltalkapi",
                        "smalltalkapisignalr",
                    },

                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequireConsent = false
                },
                // new Client
                // {
                //     ClientId = "smalltalk_client_reactjs",
                //     AllowedGrantTypes = GrantTypes.Implicit,
                //     //ClientSecrets = { new Secret("secret".Sha256())},
                //     RequireClientSecret = false,
                //     RedirectUris = new[] {"http://localhost:3003/signin-oidc"},
                //     //RefreshTokenUsage = TokenUsage.OneTimeOnly,
                //     AllowedScopes =
                //     {
                //         IdentityServerConstants.StandardScopes.OpenId,
                //         IdentityServerConstants.StandardScopes.Profile,
                //         "smalltalkapi",
                //         "smalltalkapisignalr",
                //         //IdentityServerConstants.StandardScopes.OfflineAccess
                //     },
                //     //AllowOfflineAccess = true,
                //     //AccessTokenLifetime = 60,
                //     //RefreshTokenExpiration = TokenExpiration.Sliding,
                //     RequireConsent = false,
                //     AllowedCorsOrigins = new []{"http://localhost:3003"},
                //     // PostLogoutRedirectUris = new []{"http://localhost:3003/signout-oidc"},
                //     //RequirePkce = true,
                //     // RequireClientSecret=false,
                //     
                //     //  
                //     
                //     
                //     
                //     //,
                //     
                //     // AllowAccessTokensViaBrowser = true,
                //     //AllowOfflineAccess = true,
                //     //AccessTokenLifetime = 60,
                //     //RefreshTokenExpiration = TokenExpiration.Sliding,
                //     //RequireConsent = false
                // }
            };
        }
    }
}