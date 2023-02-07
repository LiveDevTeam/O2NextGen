namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.CreateCategory;

public class CreateProductCommandResult
{
    public CreateProductCommandResult(long id, string categoryName, string categoryDescription, string categorySeries, string customerId, long addedDate, long modifiedDate, long? deletedDate, bool? isDeleted, int timeLifeInDays, int quantityCertificates, int quantityPublishCode)
    {
        Id = id;
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
        CategorySeries = categorySeries;
        CustomerId = customerId;
        AddedDate = addedDate;
        ModifiedDate = modifiedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
        TimeLifeInDays = timeLifeInDays;
        QuantityCertificates = quantityCertificates;
        QuantityPublishCode = quantityPublishCode;
    }

    public long Id { get; }
    public string CategoryName { get; }
    public string CategoryDescription { get; }
    public string CategorySeries { get; }
    public string CustomerId { get; }
    public long AddedDate { get; }
    public long ModifiedDate { get; }
    public long? DeletedDate { get; }
    public bool? IsDeleted { get; }
    public int TimeLifeInDays { get; }
    public int QuantityCertificates { get; }
    public int QuantityPublishCode { get; }
}