using System.Collections.Generic;
using O2NextGen.CertificateManagement.Domain.Entities;

public class UpdateCertificateDetailsCommandModel
{
    public string ExternalId { get; set; }
    public bool? IsDeleted { get; set; }

    public string OwnerAccountId { get; set; }
    public string CustomerId { get; set; }
    public long ExpiredDate { get; set; }
    public long PublishDate { get; set; }
    public string CreatorId { get; set; }
    public string PublishCode { get; set; }
    public bool IsVisible { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; set; }
    public ICollection<LanguageInfo> LanguageInfos { get; }
    public bool? ModifiedDate { get; internal set; }
    public string AddedDate { get; internal set; }
    public string DeletedDate { get; internal set; }
}

