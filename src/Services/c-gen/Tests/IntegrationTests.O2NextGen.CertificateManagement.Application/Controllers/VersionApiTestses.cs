using System.Threading.Tasks;
using IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Controllers;

public class VersionApiTestses : BaseIntegrationApiTests
{
    // private readonly HttpClient _httpClient;
    // public VersionApiTests()
    // {
    //     var webAppFactory = new WebApplicationFactory<Program>();
    //     _httpClient = webAppFactory.CreateDefaultClient();
    // }

    [Fact]
    public async Task VersionApi_Get_Test()
    {
        // Act
        const string url = "/version";
        var response = await HttpClient.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }
}