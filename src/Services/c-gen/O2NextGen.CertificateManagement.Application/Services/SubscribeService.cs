using Microsoft.Extensions.Options;
using O2NextGen.CertificateManagement.Application.Services.Interfaces;

namespace O2NextGen.CertificateManagement.Application.Services;

public class SubscribeService : ISubscribeService
{
    private readonly Guid _fakeTenantId = Guid.Parse("A9D99999-CF70-4EEF-8340-BCBAA4B60C4A");
    private readonly Guid _fakeProductId = Guid.Parse("A1D11999-CF99-4EEF-8340-BCBAA4B60C4A");
    private readonly IOptions<UrlsConfig> _config;
    private readonly HttpClient _httpClient;

    public SubscribeService(HttpClient httpClient, IOptions<UrlsConfig> config)
    {
        _httpClient = httpClient;
        _config = config;
    }
    
    public Guid GetTenantInfo()
    {
        return _fakeTenantId;
    }

    public Guid GetProductId()
    {
        return _fakeProductId;
    }
}