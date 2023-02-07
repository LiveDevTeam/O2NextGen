using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.NewSubscription;

public class NewSubscriptionCommandResult
{
    public NewSubscriptionCommandResult(long addedDate, long modifiedDate, string publishCode, string lockInfo,
        int lockedDate, long expiredDate, long publishDate, string creatorId, string customerId, string ownerAccountId,
        long deletedDate, long productId, Product product)
    {
        AddedDate = addedDate;
        ModifiedDate = modifiedDate;
        PublishCode = publishCode;
        LockInfo = lockInfo;
        LockedDate = lockedDate;
        ExpiredDate = expiredDate;
        PublishDate = publishDate;
        CreatorId = creatorId;
        CustomerId = customerId;
        OwnerAccountId = ownerAccountId;
        DeletedDate = deletedDate;
        ProductId = productId;
        Product = product;
    }

    public long AddedDate { get; }
    public long ModifiedDate { get; }
    public string PublishCode { get; }
    public string LockInfo { get; }
    public int LockedDate { get; }
    public long ExpiredDate { get; }
    public long PublishDate { get; }
    public string CreatorId { get; }
    public string CustomerId { get; }
    public string OwnerAccountId { get; }
    public long DeletedDate { get; }
    public long ProductId { get; }
    public Product Product { get; }
}