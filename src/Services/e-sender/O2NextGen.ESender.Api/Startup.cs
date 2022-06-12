using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.ESender.Api.IoC;
using O2NextGen.ESender.Api.Setup;
using Swashbuckle.AspNetCore.Swagger;

namespace O2NextGen.ESender.Api
{
    public class Startup
    {
        public Startup(IConfiguration appConfiguration)
        {
            AppConfiguration = appConfiguration;
        }

        public IConfiguration AppConfiguration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRequiredMvcComponents();
            services.AddBusiness();
            services.AddSwaggerGen(options =>
                        {
                            options.DescribeAllEnumsAsStrings();
                            options.SwaggerDoc("v1",new Info()
                            {
                                Title = "O2NextGen Platform. E-Sender HTTP API",
                                Version = "v1",
                                Description = "E-Sender API Service. The service allows you to send e-mail",
                                TermsOfService = "Terms of Service"
                            });
                        });
            services.AddConfigEf(AppConfiguration);
            services.ConfigurePOCO<SenderConfig>(AppConfiguration.GetSection("Sender"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Power-By", "O2NextGen: E-Sender");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });
            app.UseSwagger()
                            .UseSwaggerUI(c =>
                            {
                                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "E-Sender API V1");
                            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

