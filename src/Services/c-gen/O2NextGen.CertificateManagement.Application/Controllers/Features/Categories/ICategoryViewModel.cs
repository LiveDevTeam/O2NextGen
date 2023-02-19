using O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;

public interface ICategoryViewModel: IViewModel
{
    string CategoryName { get; set; }
    string CategoryDescription { get; set; }
    string CategorySeries { get; set; }
    string CustomerId { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
    int TimeLifeInDays { get; set; }
}