using MediatR;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.CreateCertificate
{
    public class CreateCertificateCommand : IRequest<CreateCertificateCommandResult>
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

        public long CategoryId { get; set; }
        public CategoryDbEntity Category { get; set; }
        public bool Lock { get; set; }
        public long LockedDate { get; set; }
        public string LockInfo { get; set; }
        public ICollection<LanguageInfoDbEntity> LanguageInfos { get; }

        public CreateCertificateCommand(
            string externalId, bool? IsDeleted, string ownerAccountId, string customerId,
            long expiredDate, long publishDate, string creatorId, string publishCode, bool isVisible,
            long categoryId, CategoryDbEntity category, bool @lock, long lockedDate, string lockInfo,
            ICollection<LanguageInfoDbEntity> languageInfos)
        {
            ExternalId = externalId;
            this.IsDeleted = IsDeleted;
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
    }
}

