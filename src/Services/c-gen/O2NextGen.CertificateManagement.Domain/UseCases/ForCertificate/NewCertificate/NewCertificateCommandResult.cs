using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.NewCertificate
{
    public class NewCertificateCommandResult
    {
        public NewCertificateCommandResult(long AddedDate, long ModifiedDate, string PublishCode, string LockInfo, int LockedDate, long ExpiredDate, long PublishDate, string CreatorId, string CustomerId, string OwnerAccountId, long DeletedDate, long CategoryId, Category Category, List<LanguageInfo> LanguageInfos)
        {
            this.AddedDate = AddedDate;
            this.ModifiedDate = ModifiedDate;
            this.PublishCode = PublishCode;
            this.LockInfo = LockInfo;
            this.LockedDate = LockedDate;
            this.ExpiredDate = ExpiredDate;
            this.PublishDate = PublishDate;
            this.CreatorId = CreatorId;
            this.CustomerId = CustomerId;
            this.OwnerAccountId = OwnerAccountId;
            this.DeletedDate = DeletedDate;
            this.CategoryId = CategoryId;
            this.Category = Category;
            this.LanguageInfos = LanguageInfos;
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
        public long CategoryId { get; }
        public Category Category { get; }
        public List<LanguageInfo> LanguageInfos { get; }
    }
}