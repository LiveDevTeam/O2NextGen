using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using O2NextGen.Auth.Web.StartupHelpers;
using Serilog;

namespace O2NextGen.Auth.Web
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;

        public static readonly string AppName =
            Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
        
        public static async Task<int> Main(string[] args)
        {
            try
            {
                var host = CreateWebHostBuilder(args).Build();
                Log.Information($"############### {AppName} ##############");
                Log.Information("################# Starting Application #################");
                await host.EnsureDbUpToDateAsync();
                await host.RunAsync();
                Log.Information($"============== {AppName} - state is started =====================");
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                })
                .UseStartup<Startup>();
    }
}
