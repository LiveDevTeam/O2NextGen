namespace O2NextGen.SmartSubscriber.Application.Features.Products;

public interface ICreateProductModel 
{
    string ProductName { get; set; }
    string ProductDescription { get; set; }
    string ProductCode { get; set; }
    string CustomerId { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
}