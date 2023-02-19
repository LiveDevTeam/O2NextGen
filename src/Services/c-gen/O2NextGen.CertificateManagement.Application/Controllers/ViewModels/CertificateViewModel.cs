using O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

public class CertificateViewModel :
    BaseViewModel,ICertificateViewModel
{
    public string OwnerAccountId { get; set; }
    public string CustomerId { get; set; }
    public long ExpiredDate { get; set; }
    public long PublishDate { get; set; }
    public string CreatorId { get; set; }
    public string PublishCode { get; set; }
    public bool IsVisible { get; set; }

    public long CategoryId { get; set; }
    public CategoryEntity CategoryEntity { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; set; }
    public ICollection<LanguageInfoEntity> LanguageInfos { get; }
}