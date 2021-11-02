using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Data;
using O2NextGen.CertificateManagement.Web.Helpers;
using O2NextGen.CertificateManagement.Web.IoC;
using O2NextGen.CertificateManagement.Web.Setup;

[assembly: ApiController]
namespace O2NextGen.CertificateManagement.Web
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration AppConfiguration { get; private set; }

        public Startup(IConfiguration appConfiguration, IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.AppConfiguration = appConfiguration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRequiredMvcComponents();
            services.AddBusiness();
            services.AddConfigEf(AppConfiguration);
            // services.Configure<UrlsConfig>(AppConfiguration.GetSection("Urls"));
            var result = AppConfiguration.GetSection("Urls");
            services.ConfigurePOCO<UrlsConfig>(result);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
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