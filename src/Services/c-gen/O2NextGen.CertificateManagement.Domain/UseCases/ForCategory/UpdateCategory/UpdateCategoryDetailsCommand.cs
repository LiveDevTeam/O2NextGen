using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.UpdateCategory;

public class UpdateCategoryDetailsCommand : IRequest<UpdateCategoryDetailsCommandResult>
{
    public UpdateCategoryDetailsCommand(
        long id,
        string categoryName, 
        string categoryDescription, 
        string categorySeries,
        string customerId,
        int quantityCertificates,
        int quantityPublishCode)
    {
        Id = id;
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
        CategorySeries = categorySeries;
        CustomerId = customerId;
        QuantityCertificates = quantityCertificates;
        QuantityPublishCode = quantityPublishCode;
    }

    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public string CategorySeries { get; set; }
    public string CustomerId { get; set; }
    public long? AddedDate { get; set; }
    public long? ModifiedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public int TimeLifeInDays { get; set; }
    public int QuantityCertificates { get; set; }
    public int QuantityPublishCode { get; set; }
    public long Id { get; }
}