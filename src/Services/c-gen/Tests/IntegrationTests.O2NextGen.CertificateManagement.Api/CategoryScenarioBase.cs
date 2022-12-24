using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Reflection;

namespace IntegrationTests.O2NextGen.CertificateManagement.Api
{
    public class CategoryScenarioBase
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

            return testServer;
        }
    }
}

