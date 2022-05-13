using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace O2NextGen.FeedBackX.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(options =>
                        {
                            options.DescribeAllEnumsAsStrings();
                            options.SwaggerDoc("v1",new Info()
                            {
                                Title = "O2NextGen Platform. Feedback-X HTTP API",
                                Version = "v1",
                                Description = "Feedback-X API Service. The service allows you to create feedback of o2 prodcuts",
                                TermsOfService = "Terms of Service"
                            });
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Feedback-X API V1"); });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}