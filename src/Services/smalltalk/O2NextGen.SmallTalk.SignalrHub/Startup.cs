using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.SmallTalk.SignalrHub.Hubs;
using RabbitMQ.Client;
namespace O2NextGen.SmallTalk.SignalrHub
{
    public class Startup
    {
        private IContainer  ApplicationContainer { get; set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddMvcCore(options => {
                //options.Filters.Add<ApiExceptionFilter>();
            });
            mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            mvcBuilder.AddJsonFormatters();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials());
            });
            services.AddSingleton<IChatHub,ChatHub>();
            services.AddSignalR();
            // // adds DI services to DI and configures bearer as the default scheme
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            
            }).AddJwtBearer(options =>
            {
                    // identity server issuing token
                    options.Authority = "http://localhost:5001";
                    options.RequireHttpsMetadata = false;
            
                    // // allow self-signed SSL certs
                    // options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
            
                    // the scope id of this api
                    options.Audience = "smalltalkapisignalr";
                });
            services.AddAuthorization();

            var builderAf = new ContainerBuilder();
            builderAf.Register(c =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        rmq.ExchangeType = ExchangeType.Fanout;
                    });

                }).
                As<IBusControl>()
                .As<IBus>()
                .As<IPublishEndpoint>()
                .SingleInstance();

            builderAf.Populate(services);
            ApplicationContainer = builderAf.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}
            app.UseCors("CorsPolicy");
            // adds authentication middleware to the pipeline so authentication will be performed on every request
            app.UseAuthentication();
            
            //app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseSignalR((routes) =>
            {
                routes.MapHub<ChatHub>("/chathub",options =>
                {
                    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransports.All;
                });
                
            });
            app.UseMvc();
            var bus = ApplicationContainer.Resolve<IBusControl>();
            var bushandle = TaskUtil.Await(() => bus.StartAsync());
            applicationLifetime.ApplicationStopped.Register(() => bushandle.Stop());
            
            //    app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
