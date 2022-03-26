using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace O2NetGen.OnTracker.Api.IoC
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
            // // Include DataLayer
            // // services.AddScoped<IEmailSenderService, EmailSenderService>();
            // //more business services...
            //
            // services.AddSingleton<IEmailSender, EmailSender>();
            return services;
        }

        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            // services.AddTransient<ApiExceptionFilter>();

            var mvcBuilder = services.AddMvc(options =>
            {
                // options.Filters.Add<ApiExceptionFilter>();
            });
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //var mvcBuilder = services.AddMvcCore(options =>
            //{
            //    options.Filters.Add<ApiExceptionFilter>();
            //});
            //mvcBuilder.AddJsonFormatters();

            //mvcBuilder.AddAuthorization();
            // mvcBuilder.AddFormatterMappings();
            //mvcBuilder.AddRazorViewEngine();
            //mvcBuilder.AddRazorPages();
            //mvcBuilder.AddCacheTagHelper();
            //mvcBuilder.AddDataAnnotations();

            //mvcBuilder.AddCors();
            return services;
        }
    }
}