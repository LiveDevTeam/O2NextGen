using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using O2NextGen.Auth.Web.Data;

namespace O2NextGen.Auth.Web.Extensions
{
    public static class IdentityServerExtensions
    {
        public static IServiceCollection AddConfiguredIdentityServer(this IServiceCollection services,
            IHostingEnvironment environment, IConfiguration configuration)
        {
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            // using in memory, but we could also get it, for example, from the database

            // access to data regarding the user's identity
            .AddInMemoryIdentityResources(GetIdentityResources())
            // APIs that may be accessed
            .AddInMemoryApiResources(GetApis())
            // client applications that may access users data and APIs on the user's behalf
            .AddInMemoryClients(GetClients())
            // configures IdentityServer integration with ASP.NET Core Identity
            .AddAspNetIdentity<O2User>()
            
            // to avoid bombarding the db with checks, make use of cache
            .AddInMemoryCaching();
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
        
        private static IEnumerable<ApiResource> GetApis()
        {
            var apiResource = new ApiResource("GroupManagement", "Group Management");
            apiResource.Scopes.First().Required = true;
            return new[]
            {
                apiResource
            };
        }

        private static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "WebFrontend",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = {new Secret("secret".Sha256())},
                    RedirectUris = new[] {"https://localhost:1001/signin-oidc"},
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "GroupManagement",
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 60,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    //RequireConsent = false
                }
            };
        }
    }
}