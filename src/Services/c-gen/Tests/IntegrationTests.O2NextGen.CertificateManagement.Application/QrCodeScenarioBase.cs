using System;
using IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application;

public class QrCodeScenarioBase : BaseIntegrationApiTests
{
    protected static class Get
    {
        public static readonly string QrCodeOfProfile = "api/v1.0/qrcode/profile/" + Guid.NewGuid();
        public static readonly string QrCodeOfRegisterPage = "api/v1.0/qrcode/register";
        public static readonly string GetQrCodeBasicCertificate = "api/v1.0/qrcode/qrcode-basic";
        public static readonly string GetQrCodeSignUp = "api/v1.0/qrcode/qrcode-signup";
    }
}