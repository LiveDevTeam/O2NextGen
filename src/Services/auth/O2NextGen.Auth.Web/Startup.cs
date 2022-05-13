using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using O2NextGen.Auth.Web.Data;
using O2NextGen.Auth.Web.Extensions;
using O2NextGen.Auth.Web.Helpers;
using O2NextGen.Auth.Web.Utilities;

namespace O2NextGen.Auth.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account");
                } );

            services.AddApplicationServices(_configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials());
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/AccessDenied";
            })
                .AddConfiguredIdentity(_configuration);
            services.AddConfiguredLocalization();

            services.AddSingleton<IBase64QrCodeGenerator, Base64QrCodeGenerator>();
            services.AddSingleton<IEmailSender, DummyEmailSender>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseIdentityServer();
            var v = app.ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(v);
            app.UseCookiePolicy();
            app.UseAuthentication();
            
            app.UseMvcWithDefaultRoute();
        }
    }
}
