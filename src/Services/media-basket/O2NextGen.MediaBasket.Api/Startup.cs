using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.MediaBasket.Api.Helpers;
using O2NextGen.MediaBasket.Api.IoC;
using O2NextGen.MediaBasket.Api.Setup;
using Swashbuckle.AspNetCore.Swagger;

namespace O2NextGen.MediaBasket.Api
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
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1",new Info()
                {
                    Title = "O2NextGen Platform. Media-Basket HTTP API",
                    Version = "v1",
                    Description = "Media-Basket API Service. The service allows you to create media files",
                    TermsOfService = "Terms of Service"
                });
            });
            services.AddConfigEf(AppConfiguration);
            services.ConfigurePOCO<UrlsConfig>(AppConfiguration.GetSection("Urls"));
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
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Media-Basket API V1");
                });
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Power-By", "O2NextGen: Media-Basket");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });

            app.UseMvc();
        }
    }
}
