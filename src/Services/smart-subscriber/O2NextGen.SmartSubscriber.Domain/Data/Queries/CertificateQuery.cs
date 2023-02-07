using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.Data.Queries;

public class CertificateQuery : IQuery<Subscription>
{
    public CertificateQuery(long id)
    {
        Id = id;
    }

    public CertificateQuery(string externalId, bool? isDeleted, string customerId, long expiredDate, long publishDate,
        string creatorId, string publishCode, bool isVisible, long categoryId, Product product,
        bool @lock, long lockedDate, string lockInfo, ICollection<LanguageInfo> languageInfos)
    {
        ExternalId = externalId;
        IsDeleted = isDeleted;
        CustomerId = customerId;
        ExpiredDate = expiredDate;
        PublishDate = publishDate;
        CreatorId = creatorId;
        PublishCode = publishCode;
        IsVisible = isVisible;
        CategoryId = categoryId;
        Product = product;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
        LanguageInfos = languageInfos;
    }

    public long Id { get; }
    public string ExternalId { get; }
    public bool? IsDeleted { get; }
    public string CustomerId { get; }
    public long ExpiredDate { get; }
    public long PublishDate { get; }
    public string CreatorId { get; }
    public string PublishCode { get; }
    public bool IsVisible { get; }
    public long CategoryId { get; }
    public Product Product { get; }
    public bool Lock { get; }
    public long LockedDate { get; }
    public string LockInfo { get; }
    public ICollection<LanguageInfo> LanguageInfos { get; }
}