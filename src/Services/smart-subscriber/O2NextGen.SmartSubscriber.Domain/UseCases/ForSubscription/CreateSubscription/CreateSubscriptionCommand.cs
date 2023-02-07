using MediatR;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.CreateSubscription;

public class CreateSubscriptionCommand : IRequest<CreateSubscriptionCommandResult>
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

    public long ProductId { get; set; }
    public Product Product { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; set; }

    public CreateSubscriptionCommand(
        string externalId, bool? IsDeleted, string ownerAccountId, string customerId,
        long expiredDate, long publishDate, string creatorId, string publishCode, bool isVisible,
        long productId, Product product, bool @lock, long lockedDate, string lockInfo)
    {
        ExternalId = externalId;
        this.IsDeleted = IsDeleted;
        OwnerAccountId = ownerAccountId;
        CustomerId = customerId;
        ExpiredDate = expiredDate;
        PublishDate = publishDate;
        CreatorId = creatorId;
        PublishCode = publishCode;
        IsVisible = isVisible;
        ProductId = productId;
        Product = product;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
    }
}