using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace O2NextGen.OnTracker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            host.Run();
        }

        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

