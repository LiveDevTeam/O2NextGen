namespace O2NextGen.SmartSubscriber.Domain.Entities;

public class Subscription
{
    public long Id { get; set; }
    public string ExternalId { get; set; }
    public long ModifiedDate { get; set; }
    public long AddedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }

    public string OwnerAccountId { get; set; }
    public string CustomerId { get; set; }
    public long ExpiredDate { get; set; }
    public long StartedDate { get; set; }
    public string CreatorId { get; set; }
    public string PublishCode { get; set; }
    public bool IsVisible { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; }
}