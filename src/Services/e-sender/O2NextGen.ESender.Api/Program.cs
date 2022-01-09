using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace O2NextGen.ESender.Api
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
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
#if DEBUG
                    .WriteTo.File("Logs/system_logs.txt")
#endif
                    .WriteTo.Console()
                    
                    .CreateLogger();
                
                var host = CreateWebHostBuilder(args).Build();
                Log.Information($"############### {AppName} ##############");
                Log.Information("################# Starting Application #################");
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
                .UseSerilog()
                .UseStartup<Startup>();
    }
}

