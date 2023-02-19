using IntegrationTests.O2NextGen.CertificateManagement.Application.Features;

namespace IntegrationTests.O2NextGen.CertificateManagement.Application;

public class TemplateScenarioBase : BaseIntegrationApiTests
{
    protected static class Get
    {
        public static string Templates = "api/v1.0/template";

        //public static string NewCertificates { get; set; } = $"api/v1.0/certificate/new?categoryId=1";

        //public static string CertificateBy(int id)
        //{
        //    return $"api/v1.0/certificate/{id}";
        //}
        public static string GetSettingsOtTemplate = "api/v1.0/template/config";
    }
}