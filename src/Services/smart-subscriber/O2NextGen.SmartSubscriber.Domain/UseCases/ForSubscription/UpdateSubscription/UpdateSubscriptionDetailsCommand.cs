﻿using MediatR;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.UpdateSubscription;

public class UpdateSubscriptionDetailsCommand : IRequest<UpdateSubscriptionDetailsCommandResult>
{
    public UpdateSubscriptionDetailsCommand(
        long id,
        string externalId, bool? isDeleted, string ownerAccountId, string customerId,
        long expiredDate, long publishDate, string creatorId, string publishCode, bool isVisible,
        long productId, Product product, bool @lock, long lockedDate, string lockInfo)
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
        ProductId = productId;
        Product = product;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
    }

    public UpdateSubscriptionDetailsCommand(long id, string externalId,
        bool? modifiedDate, string addedDate, string deletedDate, bool? isDeleted, 
        string ownerAccountId, string customerId, long expiredDate, long publishDate, string creatorId,
        string publishCode, bool isVisible, long productId, Product product, bool @lock, 
        long lockedDate, string lockInfo)
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
        ProductId = productId;
        Product = product;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
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
    public long ProductId { get; }
    public Product Product { get; }
    public bool Lock { get; }
    public long LockedDate { get; }
    public string LockInfo { get; }
    public bool? ModifiedDate { get; }
    public string AddedDate { get; }
    public string DeletedDate { get; }
}