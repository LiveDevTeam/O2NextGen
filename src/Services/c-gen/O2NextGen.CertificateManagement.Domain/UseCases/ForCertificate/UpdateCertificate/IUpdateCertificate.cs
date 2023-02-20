using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate;

public interface IUpdateCertificate
{
    long Id { get;}
    public string Name { get; }
    string ExternalId { get; }
    public long ModifiedDate { get; }
    public long AddedDate { get; }
    public long? DeletedDate { get; }
    public bool? IsDeleted { get; }
    public string OwnerAccountId { get; }
    public string CustomerId { get; }
    public long ExpiredDate { get; }
    public long PublishDate { get; }
    public string CreatorId { get; }
    public string PublishCode { get; }
    public bool IsVisible { get; }
    public long CategoryId { get; }
    public CategoryEntity Category { get; }
    public bool Lock { get; }
    public long LockedDate { get; }
    public string LockInfo { get;  }
    public ICollection<LanguageInfoEntity> LanguageInfos { get; }
}