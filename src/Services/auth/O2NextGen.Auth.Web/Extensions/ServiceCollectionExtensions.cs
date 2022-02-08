using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Auth.Web.Services;

namespace O2NextGen.Auth.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            //register delegating handlers
            // services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register http services
            services
                .AddHttpClient<IESenderService, ESenderService>("E-Sender", client =>
                {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("urls:ESenderUrl"));
                });

            return services;
        }
    }
}