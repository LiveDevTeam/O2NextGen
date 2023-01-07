using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResult>
    {
        public long Id { get; internal set; }
        public string CategoryName { get; internal set; }
        public string CategoryDescription { get; internal set; }
        public string CategorySeries { get; internal set; }
        public string CustomerId { get; internal set; }
        public long AddedDate { get; internal set; }
        public long ModifiedDate { get; internal set; }
        public long? DeletedDate { get; internal set; }
        public bool? IsDeleted { get; internal set; }
        public int TimeLifeInDays { get; internal set; }
        public int QuantityCertificates { get; internal set; }
        public int QuantityPublishCode { get; internal set; }
    }
}