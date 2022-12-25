using O2NextGen.CertificateManagement.Domain.Data;

namespace O2NextGen.CertificateManagement.Domain.Entities
{
    public class CertificateDbEntity
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public long ModifiedDate { get; set; }
        public long AddedDate { get; set; }
        public long? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public string OwnerAccountId { get; set; }
        public string CustomerId { get; set; }
        public long ExpiredDate { get; set; }
        public long PublishDate { get; set; }
        public string CreatorId { get; set; }
        public string PublishCode { get; set; }
        public bool IsVisible { get; set; }

        public long CategoryId { get; set; }
        public CategoryDbEntity Category { get; set; }
        public bool Lock { get; set; }
        public long LockedDate { get; set; }
        public string LockInfo { get; set; }

        public ICollection<LanguageInfoDbEntity> LanguageInfos { get; set; } = new List<LanguageInfoDbEntity>();
    }
}