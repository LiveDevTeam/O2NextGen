using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using O2NextGen.Auth.Web.Data;
using O2NextGen.Auth.Web.Extensions;
using O2NextGen.Auth.Web.Services;

namespace O2NextGen.Auth.Web
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
            
            services.AddConfiguredLocalization();
        
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer("Server=localhost;Initial Catalog=O2NextGen.AuthDb;Persist Security Info=False;User ID=sa;Password=your@Password;Connection Timeout=30;"));
            
            services
                .AddIdentity<O2User,IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddApplicationServices(Configuration);
            services.AddSingleton<IEmailSender, DummyEmailSender>();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            var v = app.ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(v);
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            

        }
    }

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
    internal class DummyEmailSender : IEmailSender
    {
        private readonly ILogger<DummyEmailSender> _logger;
        private readonly IESenderService _service;

        public DummyEmailSender(ILogger<DummyEmailSender> logger, IESenderService service)
        {
            _logger = logger;
            _service = service;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogWarning("EmailSender implementation is being used!!!!");
            _logger.LogWarning($"htmlMessage = { HttpUtility.HtmlDecode(htmlMessage)}");
            _service.Send(email,subject,htmlMessage);
            return Task.CompletedTask;
        }
    }
}
