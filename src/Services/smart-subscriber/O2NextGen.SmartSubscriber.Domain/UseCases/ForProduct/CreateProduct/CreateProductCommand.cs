using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductCommandResult>
{
    public CreateProductCommand(string customerId,
        string productName,
        string productDescription, string productCode)
    {
        ProductName = productName;
        CustomerId = customerId;
        ProductDescription = productDescription;
        ProductCode = productCode;
    }

    public string ProductName { get; }
    public string ProductDescription { get; }
    public string ProductCode { get; }
    public string CustomerId { get; }
    public long AddedDate { get; }
    public long ModifiedDate { get; }
    public long? DeletedDate { get; }
    public bool? IsDeleted { get; }
}