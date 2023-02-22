using System.Drawing;
using Microsoft.Extensions.Options;
using O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;
using O2NextGen.Sdk.NetCore.Extensions;

namespace O2NextGen.CertificateManagement.Application.Services;

public  class TemplateService : ITemplateService
{
    public enum ElementType
    {
        QrCode,
        Text,
        SpecialNumber,
        Signature,
        Stamp
    }

    private readonly IOptions<UrlsConfig> _config;
    private readonly HttpClient _httpClient;

    public TemplateService(HttpClient httpClient, IOptions<UrlsConfig> config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public Image GetTemplate(long categoryModelId)
    {
        return categoryModelId switch
        {
            //Todo: Int to Guid (this is bug)
            1 => Image.FromFile("Files/Templates/Certificates/A/pft_template_cert.png"),
            2 => Image.FromFile("Files/Templates/Certificates/AA/certificate-ab_ru.png"),
            3 => Image.FromFile("Files/Templates/Certificates/AB/certificate-bb_ru.png"),
            4 => Image.FromFile("Files/Templates/Certificates/B/pfr_template_cert_b_ru.png"),
            5 => Image.FromFile("Files/Templates/Certificates/BB/certificate-b2_ru.png"),
            _ => null
        };
    }

    public TemplateCertificate GetSettingsOtTemplate(long categoryModelId)
    {
        var templates = new List<TemplateCertificate>
        {
            new TemplateCertificate
            {
                CategoryId = 2,
                Items = new List<TemplateConfig>
                {
                    new TemplateConfig
                    {
                        Id = 1,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.Text,
                        PointY = 1150
                    },
                    new TemplateConfig
                    {
                        Id = 1,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.SpecialNumber,
                        PointY = 2204
                    },
                    new TemplateConfig
                    {
                        Id = 3,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.QrCode,
                        PointY = 2654,
                        PointX = 1600,
                        Width = 320
                    },
                    new TemplateConfig
                    {
                        Id = 4,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.QrCode,
                        PointY = 2654,
                        PointX = 1900,
                        Width = 320
                    }
                }
            },
            new TemplateCertificate
            {
                CategoryId =  1,
                Items = new List<TemplateConfig>
                {
                    new TemplateConfig
                    {
                        Id = 5,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.Text,
                        PointY = 1550
                    },

                    new TemplateConfig
                    {
                        Id = 6,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.QrCode,
                        PointY = 2901,
                        PointX = 1070,
                        Width = 400
                    },
                    new TemplateConfig
                    {
                        Id = 7,
                        ExternalId = KeyGenerator.Instance.Generate(9),
                        ModifiedDate = DateTime.Now.ConvertToUnixTime(),
                        AddedDate = DateTime.Now.ConvertToUnixTime(),
                        ElementType = ElementType.SpecialNumber,
                        PointY = 2727
                    }
                }
            }
        };

        return templates.Single(x => x.CategoryId == categoryModelId);
    }

    public class TemplateCertificate
    {
        public List<TemplateConfig> Items { get; set; }
        public long CategoryId { get; set; }
    }

    
    public class TemplateConfig : IViewModel
    {
        public ElementType ElementType { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Width { get; set; }
        public long? Id { get; set; }

        #region Basic fields

        public string ExternalId { get; set; }
        public long? ModifiedDate { get; set; }
        public long? AddedDate { get; set; }
        public long? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }

        #endregion
    }
}