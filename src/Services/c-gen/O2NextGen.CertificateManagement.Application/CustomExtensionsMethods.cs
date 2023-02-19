using O2NextGen.CertificateManagement.Application.Services;

namespace O2NextGen.CertificateManagement.Application;

internal static class CustomExtensionsMethods
{
    public static IServiceCollection AddCustomIntegrations(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICustomerService, CustomerService>();
        if (configuration["isTest"] == bool.FalseString.ToLowerInvariant())
            services.AddHttpClient<IQrCodeService, QrCodeService>();


        services.AddHttpClient<ITemplateService, TemplateService>();
        // services.AddHttpClient<ISubscribeService, SubscribeService>();
        return services;
    }
}