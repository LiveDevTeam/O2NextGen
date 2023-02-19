using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

public interface ICertificateViewModel
{
    string OwnerAccountId { get; set; }
    string CustomerId { get; set; }
    long ExpiredDate { get; set; }
    long PublishDate { get; set; }
    string CreatorId { get; set; }
    string PublishCode { get; set; }
    bool IsVisible { get; set; }

    long CategoryId { get; set; }
    CategoryEntity CategoryEntity { get; set; }
    bool Lock { get; set; }
    long LockedDate { get; set; }
    string LockInfo { get; set; }
    ICollection<LanguageInfoEntity> LanguageInfos { get; }
}