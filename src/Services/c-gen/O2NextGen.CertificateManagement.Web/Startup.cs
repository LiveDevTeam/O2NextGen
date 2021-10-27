using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Business.Services;
using O2NextGen.CertificateManagement.Impl.Services;
using O2NextGen.CertificateManagement.Web.IoC;

namespace O2NextGen.CertificateManagement.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddBusiness();
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