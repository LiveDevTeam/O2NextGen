using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace O2NextGen.CertificateManagement.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var host = CreateWebHostBuilder(args).Build();
                Console.WriteLine("################# Starting Application #################");
                await host.EnsureDbUpdate();
                await host.RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
