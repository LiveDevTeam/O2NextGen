using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.CreateCategory;

public class CreateProductCommand : IRequest<CreateProductCommandResult>
{
    private readonly long _id;

    public CreateProductCommand(string categoryName, int quantityCertificates,
        string categoryDescription, string categorySeries)
    {
        CategoryName = categoryName;
        QuantityCertificates = quantityCertificates;
        CategoryDescription = categoryDescription;
        CategorySeries = categorySeries;
    }
        
    public string CategoryName { get; }
    public string CategoryDescription { get; }
    public string CategorySeries { get; }
    public string CustomerId { get; internal set; }
    public long AddedDate { get; internal set; }
    public long ModifiedDate { get; internal set; }
    public long? DeletedDate { get; internal set; }
    public bool? IsDeleted { get; internal set; }
    public int TimeLifeInDays { get; internal set; }
    public int QuantityCertificates { get; }
    public int QuantityPublishCode { get; internal set; }
}