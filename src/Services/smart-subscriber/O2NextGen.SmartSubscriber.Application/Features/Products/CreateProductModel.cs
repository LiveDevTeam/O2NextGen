namespace O2NextGen.SmartSubscriber.Application.Features.Products;

public class CreateProductModel : ICreateProductModel
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductCode { get; set; }
    public string CustomerId { get; set; }
    public long? AddedDate { get; set; }
    public long? ModifiedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }
}