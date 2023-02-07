namespace O2NextGen.SmartSubscriber.Application.Features.Products;

public interface ICreateProductModel
{
    long Id { get; set; }
    string ProductName { get; set; }
    string ProductDescription { get; set; }
    string ProductCode { get; set; }
    long? ModifiedDate { get; set; }
    long? AddedDate { get; set; }
    long? DeletedDate { get; set; }
    bool? IsDeleted { get; set; }
    string CustomerId { get; set; }
}