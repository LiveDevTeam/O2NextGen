using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using O2NextGen.SmallTalk.Api.Helpers;
using O2NextGen.SmallTalk.Api.Services;
using Polly;
using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Util;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;

namespace O2NextGen.SmallTalk.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IContainer  ApplicationContainer { get; set; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddRequiredMvcComponents();
            services.AddBusiness();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info()
                {
                    Title = "O2NextGen Platform. SmallTalk HTTP API",
                    Version = "v1",
                    Description = "SmallTalk API Service. The service allows you to create chats",
                    TermsOfService = "Terms of Service"
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials());
            });
            // adds DI services to DI and configures bearer as the default scheme
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    // identity server issuing token
                    options.Authority = "http://localhost:5001";
                    options.RequireHttpsMetadata = false;

                    // // allow self-signed SSL certs
                    // options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };

                    // the scope id of this api
                    options.Audience = "smalltalkapi";
                });
            services.AddAuthorization();
            services.AddApplicationServices(Configuration);
            
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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/v1/swagger.json", "SmallTalk API V1"); });

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Power-By", "O2NextGen: SmallTalk API");
                    return Task.CompletedTask;
                });

                await next.Invoke();
            });
            // adds authentication middleware to the pipeline so authentication will be performed on every request
            app.UseAuthentication();
            app.UseMvc();
            
            var bus = ApplicationContainer.Resolve<IBusControl>();
            var bushandle = TaskUtil.Await(() => bus.StartAsync());
            applicationLifetime.ApplicationStopped.Register(() => bushandle.Stop());
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //register delegating handlers
            // services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register http services
            services
                .AddHttpClient<ISignalRService, SignalRService>("Signal-R",
                    client => { client.BaseAddress = new Uri(configuration.GetValue<string>("urls:SignalRUrl")); })
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(5,
                    arrempt => TimeSpan.FromSeconds(arrempt * 2)
                ));

            return services;
        }
    }
}