using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificates;

public class GetCertificatesQueryResult
{
    public GetCertificatesQueryResult(IReadOnlyCollection<CertificateViewModel> certificates)
    {
        Certificates = certificates;
    }

    public IReadOnlyCollection<CertificateViewModel> Certificates { get; }


    public class CertificateViewModel
    {
        public CertificateViewModel(
            long id, string externalId,
            long modifiedDate, long addedDate, long? deletedDate,
            bool? isDeleted, string ownerAccountId, string customerId,
            long expiredDate, long publishDate, string creatorId, string publishCode,
            bool isVisible, long categoryId, Category category, bool @lock,
            long lockedDate, string lockInfo, ICollection<LanguageInfo> languageInfos)
        {
            Id = id;

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
            Category = category;
            Lock = @lock;
            LockedDate = lockedDate;
            LockInfo = lockInfo;
            LanguageInfos = languageInfos;
        }

        public long Id { get; set; }
        public long ModifiedDate { get; }
        public long AddedDate { get; }
        public long? DeletedDate { get; }
        public bool? IsDeleted { get; }
        public string OwnerAccountId { get; }
        public string CustomerId { get; }
        public long ExpiredDate { get; }
        public long PublishDate { get; }
        public string CreatorId { get; }
        public string PublishCode { get; }
        public bool IsVisible { get; }
        public long CategoryId { get; }
        public Category Category { get; }
        public bool Lock { get; }
        public long LockedDate { get; }
        public string LockInfo { get; }
        public ICollection<LanguageInfo> LanguageInfos { get; }
    }
}