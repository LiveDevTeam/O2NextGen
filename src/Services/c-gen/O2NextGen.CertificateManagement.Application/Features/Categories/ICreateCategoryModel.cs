namespace O2NextGen.CertificateManagement.Application.Features.Categories;

public interface ICreateCategoryModel
{
    string CategoryName { get; set; }
    string CategoryDescription { get; set; }
    string CategorySeries { get; set; }
    string CustomerId { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
}