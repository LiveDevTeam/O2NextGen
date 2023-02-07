using MediatR;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.UpdateCertificate;

public class UpdateSubscriptionDetailsCommand : IRequest<UpdateSubscriptionDetailsCommandResult>
{
    public UpdateSubscriptionDetailsCommand(
        long id,
        string externalId, bool? isDeleted, string ownerAccountId, string customerId,
        long expiredDate, long publishDate, string creatorId, string publishCode, bool isVisible,
        long categoryId, Product product, bool @lock, long lockedDate, string lockInfo,
        ICollection<LanguageInfo> languageInfos)
    {
        Id = id;
        ExternalId = externalId;
        IsDeleted = isDeleted;
        OwnerAccountId = ownerAccountId;
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

    public UpdateSubscriptionDetailsCommand(long id, string externalId, bool? modifiedDate, string addedDate, string deletedDate, bool? isDeleted, string ownerAccountId, string customerId, long expiredDate, long publishDate, string creatorId, string publishCode, bool isVisible, long categoryId, Product product, bool @lock, long lockedDate, string lockInfo, ICollection<LanguageInfo> languageInfos)
    {
        Id = id;
        ExternalId = externalId;
        ModifiedDate = modifiedDate;
        AddedDate = addedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
        OwnerAccountId = ownerAccountId;
        CustomerId = customerId;
        ExpiredDate = expiredDate;
        PublishDate = publishDate;
        CreatorId = creatorId;
        PublishCode = publishCode;
        IsVisible = isVisible;
        CategoryId = categoryId;
        Category1 = product;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
        LanguageInfos1 = languageInfos;
    }

    public long Id { get; }
    public string ExternalId { get; }
    public bool? IsDeleted { get; }
    public string OwnerAccountId { get; }
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
    public bool? ModifiedDate { get; }
    public string AddedDate { get; }
    public string DeletedDate { get; }
    public Product Category1 { get; }
    public ICollection<LanguageInfo> LanguageInfos1 { get; }
}