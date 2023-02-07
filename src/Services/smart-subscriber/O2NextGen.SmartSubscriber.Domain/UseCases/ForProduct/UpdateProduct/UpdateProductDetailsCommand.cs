using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.UpdateCategory;

public class UpdateProductDetailsCommand : IRequest<UpdateProductDetailsCommandResult>
{
    public UpdateProductDetailsCommand(
        long id,
        string productName, 
        string productDescription, 
        string productCode,
        string customerId)
    {
        Id = id;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductCode = productCode;
        CustomerId = customerId;
    }

    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductCode { get; set; }
    public string CustomerId { get; set; }
    public long? AddedDate { get; set; }
    public long? ModifiedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public long Id { get; }
}