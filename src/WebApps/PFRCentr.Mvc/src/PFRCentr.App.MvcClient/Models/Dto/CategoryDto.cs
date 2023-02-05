namespace PFRCentr.App.MvcClient.Models.Dto;

public class CertificateDto
{
    public long Id { get; set; }
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
    public CategoryDto Category { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; set; }
    //public ICollection<LanguageInfo> LanguageInfos { get; }
    public bool? ModifiedDate { get; internal set; }
    public string AddedDate { get; internal set; }
    public string DeletedDate { get; internal set; }

}
public class CategoryDto
{
    public long Id { get;  set; }
    public string CategoryName { get;  set; }
    public string CategoryDescription { get;  set; }
    public string CategorySeries { get;  set; }
    public string CustomerId { get;  set; }
    public long? AddedDate { get;  set; }
    public long? ModifiedDate { get;  set; }
    public long? DeletedDate { get;  set; }
    public bool? IsDeleted { get;  set; }
    public int TimeLifeInDays { get;  set; }
    public int QuantityCertificates { get;  set; }
    public int QuantityPublishCode { get;  set; }
}