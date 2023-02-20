using System.Net.Http;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class BaseIntegrationApiTests
{
    private readonly CustomWebApplicationFactory<Program> _webAppFactory = new CustomWebApplicationFactory<Program>();

    protected BaseIntegrationApiTests()
    {
        HttpClient = _webAppFactory.CreateDefaultClient();
        Context = _webAppFactory.Context;
    }

    protected CGenDbContext Context { get; }

    protected HttpClient HttpClient { get; set; }
}