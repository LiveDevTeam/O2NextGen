namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.CreateCategory;

public class CreateProductCommandResult
{
    public CreateProductCommandResult(long id, string productName, string productDescription, 
        string productCode, string customerId, long addedDate, long modifiedDate, long? deletedDate,
        bool? isDeleted)
    {
        Id = id;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductCode = productCode;
        CustomerId = customerId;
        AddedDate = addedDate;
        ModifiedDate = modifiedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
    }

    public long Id { get; }
    public string ProductName { get; }
    public string ProductDescription { get; }
    public string ProductCode { get; }
    public string CustomerId { get; }
    public long AddedDate { get; }
    public long ModifiedDate { get; }
    public long? DeletedDate { get; }
    public bool? IsDeleted { get; }
}