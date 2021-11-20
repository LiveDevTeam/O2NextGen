using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using O2NextGen.Auth.Web.Data;
using O2NextGen.Auth.Web.Extensions;

namespace O2NextGen.Auth.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddConfiguredLocalization();
        
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer("Server=localhost;Initial Catalog=O2NextGen.AuthDb;Persist Security Info=False;User ID=sa;Password=your@Password;Connection Timeout=30;"));
            
            services
                .AddIdentity<O2User,IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            
            
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

    internal class DummyEmailSender : IEmailSender
    {
        private readonly ILogger<DummyEmailSender> _logger;

        public DummyEmailSender(ILogger<DummyEmailSender> logger)
        {
            _logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogWarning("EmailSender implementation is being used!!!!");
            _logger.LogWarning($"htmlMessage = { HttpUtility.HtmlDecode(htmlMessage)}");
            return Task.CompletedTask;
        }
    }
}
