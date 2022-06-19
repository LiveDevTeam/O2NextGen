using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.MediaBasket.Api.Filters;
using O2NextGen.MediaBasket.Api.Services;
using O2NextGen.MediaBasket.Business.Services;
using O2NextGen.MediaBasket.Data;
using O2NextGen.MediaBasket.Impl.Services;

namespace O2NextGen.MediaBasket.Api.IoC
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

        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            services.AddTransient<ApiExceptionFilter>();

            var mvcBuilder = services.AddMvcCore(options => { options.Filters.Add<ApiExceptionFilter>(); });
            mvcBuilder.AddApiExplorer(); //for swagger
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            mvcBuilder.AddJsonFormatters();
            return services;
        }

        public static IServiceCollection AddConfigEf(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<MadiaManagementDbContext>(x =>
                x.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            //services.AddSingleton<IMediaService, InMemoryMediaService>();
            services.AddSingleton<Business.Services.ICloudStorageManager, CloudinaryStorageService>();
            // Include DataLayer
            services.AddScoped<IMediaService, MediaService>();
            //more business services...

            return services;
        }
    }
}