using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Impl.Services;

namespace O2NextGen.CertificateManagement.Web.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<ICertificatesService, InMemoryCertificatesService>();
            //more business services...
            
            return services;
        }
    }
}