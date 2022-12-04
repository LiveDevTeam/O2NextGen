using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace O2NextGen.CertificateManagement.Api
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
                var host = CreateHostBuilder(args);
                Log.Information($"############### {AppName} ##############");
                Log.Information("################# Starting Application #################");
                await host.EnsureDbUpdate();
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

        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                })
                .UseStartup<Startup>()
                .Build(); 
    }
}
