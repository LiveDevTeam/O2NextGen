using System.Drawing;

namespace O2NextGen.CertificateManagement.Application.Services;

    public interface ITemplateService
    {
        Image GetTemplate(long categoryModelId);
        TemplateService.TemplateCertificate GetSettingsOtTemplate(long categoryModelId);
    }
public interface ICustomerService
{
    Guid CustomerId { get; }
    string CustomerDescription { get; set; }
    string RegisterLink { get; set; }
    string AccountLink { get; set; }
}