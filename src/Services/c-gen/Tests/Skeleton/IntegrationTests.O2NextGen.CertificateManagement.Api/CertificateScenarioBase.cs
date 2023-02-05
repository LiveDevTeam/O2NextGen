using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace IntegrationTests.O2NextGen.CertificateManagement.Api;

public class CertificateScenarioBase
{
    public TestServer CreateServer()
    {
        var path = Assembly.GetAssembly(typeof(CertificateScenarioBase))
            .Location;

        var hostBuilder = new WebHostBuilder()
            .UseContentRoot(Path.GetDirectoryName(path))
            .ConfigureAppConfiguration(cb =>
            {
                // cb.AddJsonFile("appsettings.json", false)
                //     .AddEnvironmentVariables();
            }).UseStartup<TestsStartup>();

        var testServer = new TestServer(hostBuilder);

        //testServer.Host
        //.MigrateDbContext<CertificateDataContext>((context, services) =>
        //{
        //        var env = services.GetService<IWebHostEnvironment>();
        //        var settings = services.GetService<IOptions<OrderingSettings>>();
        //        var logger = services.GetService<ILogger<CertificateDataContext>>();

        //        //new CertificateDataContext()
        //        //    .SeedAsync(context, env, settings, logger)
        //        //    .Wait();
        //})
        //.MigrateDbContext<IntegrationEventLogContext>((_, __) => { });

        return testServer;
    }

    public static class Get
    {
        public static string Certificates = "certificates";
         
        public static string CertificateBy(int id)
        {
            return $"certificates/{id}";
        }
    }

    public static class Put
    {
        //    public static string CancelOrder = "api/v1/orders/cancel";
        //    public static string ShipOrder = "api/v1/orders/ship";
    }

    public static class Post
    {

    }
}