using System.Runtime.Serialization;

namespace O2NextGen.CertificateManagement.Application.Features.Categories
{
    public class CreateCategoryModel : ICreateCategoryModel
    {
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
    }
}