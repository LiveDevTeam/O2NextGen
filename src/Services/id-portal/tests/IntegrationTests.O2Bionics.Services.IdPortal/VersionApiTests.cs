using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace IntegrationTests.O2Bionics.Services.IdPortal;

public class VersionApiTests
{
    private readonly HttpClient _httpClient;
    public VersionApiTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }
    
    [Fact]
    public async Task VersionApi_Get_Test()
    {
        // Act
        const string url = "/version";
        var response = await _httpClient.GetAsync(url);
        
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
    }
}