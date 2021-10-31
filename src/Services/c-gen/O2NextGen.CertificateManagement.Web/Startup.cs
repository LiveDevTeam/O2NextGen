using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Data;
using O2NextGen.CertificateManagement.Web.IoC;

namespace O2NextGen.CertificateManagement.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddBusiness();
            services.AddDbContext<CertificateManagementDbContext>(x =>
                x.UseSqlServer("Server=localhost;Initial Catalog=O2NextGen.CertificateDb;Persist Security Info=False;User ID=sa;Password=your@Password;Connection Timeout=30;"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Power-By", "O2NextGen: C-Gen");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });

            app.UseMvc();
        }
    }
}