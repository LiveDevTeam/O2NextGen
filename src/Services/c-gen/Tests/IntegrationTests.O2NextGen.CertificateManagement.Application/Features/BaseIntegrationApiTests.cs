using System.Net.Http;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class BaseIntegrationApiTests
{
    private readonly CustomWebApplicationFactory<Program> webAppFactory;

    public BaseIntegrationApiTests()
    {
        webAppFactory = new CustomWebApplicationFactory<Program>(); //
        _httpClient = webAppFactory.CreateDefaultClient();
        context = webAppFactory.Context;
    }

    public CGenDbContext context { get; }

    public HttpClient _httpClient { get; set; }
}