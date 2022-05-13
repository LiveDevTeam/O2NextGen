using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NetGen.OnTracker.Api.IoC;
using O2NetGen.OnTracker.Api.Setup;
using O2NextGen.Tracker.DbUtility;
using Swashbuckle.AspNetCore.Swagger;

namespace O2NetGen.OnTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration appConfiguration)
        {
            AppConfiguration = appConfiguration;
        }

        public IConfiguration AppConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRequiredMvcComponents();
            // services.AddSingleton<IGeoDbSetting, GeoDbSetting>();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1",new Info()
                {
                    Title = "O2NextGen Platform. On-Tracker HTTP API",
                    Version = "v1",
                    Description = "On-Tracker API Service. The service allows you to create certificates",
                    TermsOfService = "Terms of Service"
                });
            });
            services.ConfigurePOCO<GeoDatabase>(AppConfiguration.GetSection("GeoDatabase"));
            services.AddScoped<IGeoIpAddressResolver, MaxMindLocalGeoIpAddressResolver>();
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
                .UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/v1/swagger.json", "On-Tracker API V1"); });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}