namespace IdPortal.App.MvcClient.Models.Dto;

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
    public UserDto User { get; set; }
    public bool Lock { get; set; }
    public long LockedDate { get; set; }
    public string LockInfo { get; set; }
    //public ICollection<LanguageInfo> LanguageInfos { get; }
    public bool? ModifiedDate { get; internal set; }
    public string AddedDate { get; internal set; }
    public string DeletedDate { get; internal set; }

}
public class UserDto
{
    public string Id { get;  set; }
    public string UserName { get;  set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public bool LockoutEnabled { get;  set; }
    public string PhoneNumber { get;  set; }
    public DateTimeOffset? LockoutEnd { get;  set; }
    public bool PhoneNumberConfirmed { get;  set; }
    public bool EmailConfirmed { get;  set; }
    public int AccessFailedCount { get;  set; }
}