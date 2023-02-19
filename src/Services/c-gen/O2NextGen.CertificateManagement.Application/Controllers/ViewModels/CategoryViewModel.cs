using O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;
using O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;

namespace O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

public class CategoryViewModel : BaseViewModel, ICategoryViewModel
{
    public int TimeLifeInDays { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public string CategorySeries { get; set; }
    public string CustomerId { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
}