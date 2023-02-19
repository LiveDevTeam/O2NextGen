using System.Threading.Tasks;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class TemplateControllerTests : TemplateScenarioBase
{
    [Fact]
    public async Task GetImageOfCertificate()
    {
        var response = await _httpClient
            .GetAsync(Get.Templates);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetSettingsOtTemplate()
    {
        var response = await _httpClient
            .GetAsync(Get.GetSettingsOtTemplate);

        response.EnsureSuccessStatusCode();
    }
}