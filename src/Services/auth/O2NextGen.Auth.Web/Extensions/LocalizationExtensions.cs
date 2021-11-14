using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace O2NextGen.Auth.Web.Extensions
{
    public static class LocalizationExtensions
    {
        public static IServiceCollection AddConfiguredLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services
                .Configure<RequestLocalizationOptions>(options =>
                {
                    var cultures = new[]
                    {
                        new CultureInfo("en"),
                        new CultureInfo("ru"),
                        new CultureInfo("de"),
                        new CultureInfo("tr"),
                        new CultureInfo("he"), 
                    };
                    options.DefaultRequestCulture = new RequestCulture("ru");
                    options.SupportedCultures = cultures;
                    options.SupportedUICultures = cultures;
                });

            return services;
        }
    }
}