using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.OnTracker.Api.IoC;
using O2NextGen.OnTracker.Api.Setup;
using O2NextGen.Tracker.DbUtility;

namespace O2NextGen.OnTracker.Api
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

