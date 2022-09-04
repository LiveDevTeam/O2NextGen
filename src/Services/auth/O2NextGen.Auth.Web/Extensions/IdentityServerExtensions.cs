using System.Collections.Generic;
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
                profile,
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
                new ApiResource("smalltalkapi", "SmallTalk API"),
                new ApiResource("smalltalksignalr","SmallTalk SignalR")
            };

        private static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                //blazor pfr-center
                new Client()
                {
                    ClientName = "client.pfrcenter.blazor",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = {
                    //IdentityServerConstants.StandardScopes.Address,
                    //IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    },
                    RedirectUris =
                    {
                        "https://localhost:7001/authentication/login-callback "
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7001/authentication/logout-callback "
                    },
                    AllowedCorsOrigins = { "https://localhost:7001" },
                    AllowAccessTokensViaBrowser = true,
                },
            // React client
            new Client
                {
                    ClientId = "smalltalk_client_reactjs",
                    ClientName = "SmallTalk React App",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:3003/signin-oidc",
                    },


                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "smalltalkapi",
                        "smalltalksignalr",
                    },

                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequireConsent = false
                },
                new Client
                {
                    ClientId = "smalltalkapi",
                    ClientName = "Smalltalkapi Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"http://localhost:5003/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"http://localhost:5003/swagger/" },

                     AllowedScopes = new List<string>
                     {
                        "smalltalkapi"
                     }
                },
                new Client {
                    ClientId = "o2business-wpf",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost/sample-wpf-app" },
                    AllowedCorsOrigins = { "http://localhost" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },
                new Client {
                    ClientId = "xamarin",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "xamarinformsclients://callback" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },

            };
        }
    }
}