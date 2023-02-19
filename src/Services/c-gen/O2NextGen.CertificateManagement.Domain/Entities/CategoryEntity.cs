using O2NextGen.CertificateManagement.Domain.Data;

namespace O2NextGen.CertificateManagement.Domain.Entities;

public class CategoryEntity : BaseEntity, ICategoryEntity
{
    public string CustomerId { get; set; }
    public string CategorySeries { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public int TimeLifeInDays { get; set; }
}

public interface ICategoryEntity
{
    string CustomerId { get; set; }
    string CategorySeries { get; set; }
    int QuantityCertificates { get; set; }
    int QuantityPublishCode { get; set; }
    string CategoryName { get; set; }
    string CategoryDescription { get; set; }
    int TimeLifeInDays { get; set; }
}