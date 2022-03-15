using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.SmallTalk.Api.Services;
using System;

namespace O2NextGen.SmallTalk.Api.Helpers
{
    public static class ServiceCollectionExtensions
    {
        // ReSharper disable once InconsistentNaming
        public static TConfig ConfigurePOCO<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();
            configuration.Bind(config);
            services.AddSingleton(config);
            return config;
        }


        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            // services.AddSingleton<IEmailSenderService, InMemoryEmailSenderService>();
            // Include DataLayer
            //services.AddScoped<IChatService, InMemoryChatService>();
            //more business services...

            services.AddSingleton<IChatService, InMemoryChatService>();
            return services;
        }

        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            //services.AddTransient<ApiExceptionFilter>();

            var mvcBuilder = services.AddMvc(options =>
            {
                //    options.Filters.Add<ApiExceptionFilter>();
            });
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            return services;
        }
    }
}

