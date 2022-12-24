using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.CertificateManagement.Api.Setup;
using O2NextGen.CertificateManagement.Api.Helpers;
using O2NextGen.CertificateManagement.Api.IoC;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

[assembly: ApiController]
namespace O2NextGen.CertificateManagement.Api
{
    public class Startup
    {
        public IWebHostEnvironment HostingEnvironment { get; private set; }
        public IConfiguration AppConfiguration { get; private set; }

        public Startup(IConfiguration appConfiguration, IWebHostEnvironment env)
        {
            this.HostingEnvironment = env;
            this.AppConfiguration = appConfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRequiredMvcComponents();
            services.AddBusiness();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1",new OpenApiInfo()
                {
                    Title = "O2NextGen Platform. C-Gen HTTP API",
                    Version = "v1",
                    Description = "C-Gen API Service. The service allows you to create certificates",
                    //TermsOfService = "Terms of Service"
                });
            });
            services.AddConfigEf(AppConfiguration);
            services.ConfigurePOCO<UrlsConfig>(AppConfiguration.GetSection("Urls"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "C-Gen API V1");
                });
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Power-By", "O2NextGen: C-Gen");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}