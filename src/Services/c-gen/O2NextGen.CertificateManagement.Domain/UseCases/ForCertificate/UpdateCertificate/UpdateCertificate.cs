﻿using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate;

public class UpdateCertificate: IUpdateCertificate
{
    public UpdateCertificate(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public UpdateCertificate(long id, string name, long modifiedDate, long addedDate,
        long? deletedDate, bool? isDeleted, string ownerAccountId, string customerId, long expiredDate,
        long publishDate, string creatorId, string publishCode, bool isVisible, long categoryId, CategoryEntity categoryEntity,
        bool @lock, long lockedDate, string lockInfo, ICollection<LanguageInfoEntity> languageInfos) : this(id, name)
    {
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
        CategoryEntity = categoryEntity;
        Lock = @lock;
        LockedDate = lockedDate;
        LockInfo = lockInfo;
        LanguageInfos = languageInfos;
    }

    public long Id { get; }
    public string Name { get; }
    public string ExternalId { get; }
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
    public CategoryEntity CategoryEntity { get; }
    public bool Lock { get; }
    public long LockedDate { get; }
    public string LockInfo { get; }
    public ICollection<LanguageInfoEntity> LanguageInfos { get; }
}