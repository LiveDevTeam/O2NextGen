using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Helpers;
using O2NextGen.CertificateManagement.Application.Services;
using QRCoder;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.QRCodes;

[Authorize]
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[ApiController]
// ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
[Route("api/v{v:apiVersion}/[controller]")]
public class QrCodeController : ControllerBase
{
    #region Ctors

    public QrCodeController(ICustomerService customerService, IIdentityService identityService)
    {
        _customerService = customerService;
        _identityService = identityService;
    }

    #endregion

    [AllowAnonymous]
    [HttpGet("profile/{accountId}")]
    public IActionResult GetProfile([FromQuery] Guid accountId, [FromQuery] int size = 500)
    {
        var description = _customerService.CustomerDescription;
        var registerShortLink = _customerService.AccountLink + "/" + accountId;

        var qrCodeContent = "Profile of Specialist #PF_R" + " " + registerShortLink;
        var qrCodeSize = new QrCodeSize {Width = size, Height = size};

        var qrCodeBitmap = new Bitmap(qrCodeSize.Width, qrCodeSize.Height, PixelFormat.Format24bppRgb);

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(
            qrCodeContent,
            QRCodeGenerator.ECCLevel.H);
        var qrCode = new QRCode(qrCodeData);

        var qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, null);
        var bitmapClear = new Bitmap(qrCodeSize.Width, qrCodeSize.Height);
        using (var graphics = Graphics.FromImage(bitmapClear))
        {
            graphics.DrawImage(qrCodeBitmap, 0, 0, qrCodeBitmap.Width, qrCodeBitmap.Height);
            //var image = Image.FromFile("Files/pfr-community_logo.png");
            //int left = (qrCodeBitmap.Width / 2) - (image.Width / 2);
            //int top = (qrCodeBitmap.Height / 2) - (image.Height / 2); 
            graphics.DrawImage(qrCodeImage, 0, 0, qrCodeSize.Width, qrCodeSize.Height);
            //graphics.DrawImage(image, new Point(left, top));
            //var fullNumber = certificationSerial + certificationNumber;
            //ImageHelper.AddedText(fullNumber, qrCodeBitmap, graphics, "Arial", 18, Brushes.Black, top + 30,
            //    StringAlignment.Center, StringAlignment.Center);
            graphics.Save();
        }

        var bitmapBytes = ImageHelper.BitmapToBytes(bitmapClear); //Convert bitmap into a byte array

        return File(bitmapBytes, "image/jpeg");
    }

    [AllowAnonymous]
    [HttpGet("register")]
    public IActionResult GetQrCodeOfRegisterPage([FromQuery] int size = 500)
    {
        var certificationSerial = "A";
        var certificationNumber = "020619890";

        //Todo: I will add the short link
        var registerShortLink = _customerService.RegisterLink;
        var qrCodeContent = _customerService.CustomerDescription + " " + registerShortLink;

        var qrCodeSize = new QrCodeSize {Width = size, Height = size};

        var qrCodeBitmap = new Bitmap(qrCodeSize.Width, qrCodeSize.Height, PixelFormat.Format24bppRgb);

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(
            qrCodeContent,
            QRCodeGenerator.ECCLevel.H);
        var qrCode = new QRCode(qrCodeData);

        var qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, null);
        var bitmapClear = new Bitmap(qrCodeSize.Width, qrCodeSize.Height);
        using (var graphics = Graphics.FromImage(bitmapClear))
        {
            graphics.DrawImage(qrCodeBitmap, 0, 0, qrCodeBitmap.Width, qrCodeBitmap.Height);
            var image = Image.FromFile("Files/pfr-community_logo.png");
            var left = qrCodeBitmap.Width / 2 - image.Width / 2;
            var top = qrCodeBitmap.Height / 2 - image.Height / 2;
            graphics.DrawImage(qrCodeImage, 0, 0, qrCodeSize.Width, qrCodeSize.Height);
            graphics.DrawImage(image, new Point(left, top));
            var fullNumber = certificationSerial + certificationNumber;
            ImageHelper.AddedText(fullNumber, qrCodeBitmap, graphics, "Arial", 18, Brushes.Black, top + 30,
                StringAlignment.Center, StringAlignment.Center);
            graphics.Save();
        }

        var bitmapBytes = ImageHelper.BitmapToBytes(bitmapClear); //Convert bitmap into a byte array

        return File(bitmapBytes, "image/jpeg");
    }

    [AllowAnonymous]
    [HttpGet("qrcode-basic")]
    public IActionResult GetQrCodeBasicCertificate([FromQuery(Name = "size")] int size = 500)
    {
        var certificationAccountId = "";
        var qrCodeContent = "Profile of Specialist #PF_R" + " https://pfr-centr.com/pages/profile/" +
                            certificationAccountId;
        var qrCodeSize = new QrCodeSize {Width = size, Height = size};

        var qrCodeBitmap = new Bitmap(qrCodeSize.Width, qrCodeSize.Height, PixelFormat.Format24bppRgb);

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(
            qrCodeContent,
            QRCodeGenerator.ECCLevel.H);
        var qrCode = new QRCode(qrCodeData);

        var qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, null);
        var bitmapClear = new Bitmap(qrCodeSize.Width, qrCodeSize.Height);
        using (var graphics = Graphics.FromImage(bitmapClear))
        {
            graphics.DrawImage(qrCodeBitmap, 0, 0, qrCodeBitmap.Width, qrCodeBitmap.Height);
            //var image = Image.FromFile("Files/pfr-community_logo.png");
            //int left = (qrCodeBitmap.Width / 2) - (image.Width / 2);
            //int top = (qrCodeBitmap.Height / 2) - (image.Height / 2); 
            graphics.DrawImage(qrCodeImage, 0, 0, qrCodeSize.Width, qrCodeSize.Height);
            //graphics.DrawImage(image, new Point(left, top));
            //var fullNumber = certificationSerial + certificationNumber;
            //ImageHelper.AddedText(fullNumber, qrCodeBitmap, graphics, "Arial", 18, Brushes.Black, top + 30,
            //    StringAlignment.Center, StringAlignment.Center);
            graphics.Save();
        }

        var bitmapBytes = ImageHelper.BitmapToBytes(bitmapClear); //Convert bitmap into a byte array

        return File(bitmapBytes, "image/jpeg");
    }

    [AllowAnonymous]
    [HttpGet("qrcode-signup")]
    public IActionResult GetQrCodeBasicSignUp([FromQuery(Name = "size")] int size = 500)
    {
        var certificationAccountId = "";
        var qrCodeContent = "Profile of Specialist #PF_R" + " https://pfr-centr.com/pages/profile/" +
                            certificationAccountId;
        var qrCodeSize = new QrCodeSize {Width = size, Height = size};

        var qrCodeBitmap = new Bitmap(qrCodeSize.Width, qrCodeSize.Height, PixelFormat.Format24bppRgb);

        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(
            qrCodeContent,
            QRCodeGenerator.ECCLevel.H);
        var qrCode = new QRCode(qrCodeData);

        var qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, null);
        var bitmapClear = new Bitmap(qrCodeSize.Width, qrCodeSize.Height);
        using (var graphics = Graphics.FromImage(bitmapClear))
        {
            graphics.DrawImage(qrCodeBitmap, 0, 0, qrCodeBitmap.Width, qrCodeBitmap.Height);
            //var image = Image.FromFile("Files/pfr-community_logo.png");
            //int left = (qrCodeBitmap.Width / 2) - (image.Width / 2);
            //int top = (qrCodeBitmap.Height / 2) - (image.Height / 2); 
            graphics.DrawImage(qrCodeImage, 0, 0, qrCodeSize.Width, qrCodeSize.Height);
            //graphics.DrawImage(image, new Point(left, top));
            //var fullNumber = certificationSerial + certificationNumber;
            //ImageHelper.AddedText(fullNumber, qrCodeBitmap, graphics, "Arial", 18, Brushes.Black, top + 30,
            //    StringAlignment.Center, StringAlignment.Center);
            graphics.Save();
        }

        var bitmapBytes = ImageHelper.BitmapToBytes(bitmapClear); //Convert bitmap into a byte array

        return File(bitmapBytes, "image/jpeg");
    }

    #region Fields

    private readonly ICustomerService _customerService;
    private readonly IIdentityService _identityService;

    #endregion
}