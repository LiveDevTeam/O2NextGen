using System.Threading.Tasks;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

public class QrCodeControllerTests : QrCodeScenarioBase
{
    [Fact]
    public async Task GetQrCodeOfProfile()
    {
        var response = await _httpClient.GetAsync(Get.QrCodeOfProfile);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetQrCodeOfRegisterPage()
    {
        var response = await _httpClient.GetAsync(Get.QrCodeOfRegisterPage);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetQrCodeBasicCertificate()
    {
        var response = await _httpClient.GetAsync(Get.GetQrCodeBasicCertificate);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetQrCodeSignUp()
    {
        var response = await _httpClient.GetAsync(Get.GetQrCodeSignUp);
        response.EnsureSuccessStatusCode();
    }
}