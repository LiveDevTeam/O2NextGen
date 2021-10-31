using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Impl.Services;
using O2NextGen.CertificateManagement.Web.Filters;

namespace O2NextGen.CertificateManagement.Web.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequiredMvcComponents(this IServiceCollection services)
        {
            services.AddTransient<ApiExceptionFilter>();
            
            var mvcBuilder = services.AddMvcCore(options =>
            {
                options.Filters.Add<ApiExceptionFilter>();
            } );
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            mvcBuilder.AddJsonFormatters();
            return services;
        }
        
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            // services.AddSingleton<ICertificatesService, InMemoryCertificatesService>();
            // Include DataLayer
            services.AddScoped<ICertificatesService, CertificatesService>();
            //more business services...
            
            return services;
        }
    }
}