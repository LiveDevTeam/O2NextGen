using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.Web.BFF.Core.Config;
using O2NextGen.Web.BFF.Core.Features.E_Sender.Services;

namespace O2NextGen.Web.BFF.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc(Configuration);
            services.AddApplicationServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
    
    //Todo: will move to file
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<UrlsConfig>(configuration.GetSection("urls"));

            var mvcBuilder = services.AddMvcCore();
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            mvcBuilder.AddJsonFormatters();
            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            // var identityUrl = configuration.GetValue<string>("urls:e-sender");
            // services.AddAuthentication(options =>
            //     {
            //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //
            //     })
            //     .AddJwtBearer(options =>
            //     {
            //         options.Authority = identityUrl;
            //         options.RequireHttpsMetadata = false;
            //         options.Audience = "webshoppingagg";
            //     });

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //register delegating handlers
            // services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register http services
            services
                .AddHttpClient<IESenderService, ESenderService>();

            return services;
        }
    }
}

