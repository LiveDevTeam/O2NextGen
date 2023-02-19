using System.Drawing;
using Microsoft.Extensions.Options;
using O2NextGen.CertificateManagement.Application.IoC;
using O2NextGen.Sdk.NetCore.Extensions;

namespace O2NextGen.CertificateManagement.Application.Services;

public class QrCodeService : IQrCodeService
{
    private readonly IOptions<UrlsConfig> _config;
    private readonly HttpClient _httpClient;

    public QrCodeService(HttpClient httpClient, IOptions<UrlsConfig> config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<Image> GetQrCodeBasicCertificate(long certificateId, int sizeQrCode)
    {
        var timeFile = DateTime.Now.ConvertToUnixTime();
        var rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        var response =
            await _httpClient.GetAsync(_config.Value.CGenUrl + $"/api/v1.0/qrcode/qrcode-basic?size=" + sizeQrCode);
        //Log.Debug("get users: {response}", response);
        //Directory.SetCurrentDirectory(rootDir);
        if (!Directory.Exists("Cache"))
        {
            Directory.CreateDirectory("Cache");
        }

        var randomId = new Random(1000);
        await response.Content.ReadAsFileAsync(@"Cache\certificate" + "_" + timeFile + "_" + randomId + ".jpg", true);
        var image = Image.FromFile(@"Cache\certificate" + "_" + timeFile + "_" + randomId + ".jpg");
        //await Task.Factory.StartNew(() =>
        //{
        //    File.Delete(@"Cache\certificate" + "_" + timeFile + "_" + randomId + ".jpg");
        //});

        //var obj = JsonConvert.DeserializeObject<List<UserViewM>>(json);
        return image;
    }
}