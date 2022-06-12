using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace O2NextGen.SmallTalk.SignalrHub
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
        public static int Main(string[] args)
        {
            try
            {
                //Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                var host = CreateWebHostBuilder(args).Build();
                //Log.Information("Starting web host ({ApplicationContext})...", AppName);
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                return 1;
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
