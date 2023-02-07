namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.GetProduct;

public class GetProductQueryResult
{
    public GetProductQueryResult(
        long id, long modifiedDate, long addedDate, long? deletedDate, bool? isDeleted,
        string customerId,
        string productName,
        string productDescription,
        string productCode)
    {
        Id = id;
        ModifiedDate = modifiedDate;
        AddedDate = addedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
        CustomerId = customerId;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductCode = productCode;
    }


    public long Id { get; }
    public long ModifiedDate { get; }
    public long AddedDate { get; }
    public long? DeletedDate { get; }
    public bool? IsDeleted { get; }
    public string CustomerId { get; }
    public string ProductName { get; }
    public string ProductDescription { get; }
    public string ProductCode { get; }
}