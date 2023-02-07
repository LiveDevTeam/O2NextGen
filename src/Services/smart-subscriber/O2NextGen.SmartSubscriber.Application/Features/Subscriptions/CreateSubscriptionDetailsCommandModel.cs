using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Application.Features.Subscriptions;

public class CreateSubscriptionDetailsCommandModel
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
    public ICollection<LanguageInfo> LanguageInfos { get; }
}