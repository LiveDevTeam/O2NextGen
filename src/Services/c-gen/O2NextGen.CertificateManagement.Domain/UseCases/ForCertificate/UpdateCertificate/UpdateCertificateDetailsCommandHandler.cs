using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate;

public class UpdateCertificateDetailsCommandHandler
    : IRequestHandler<UpdateCertificateDetailsCommand, global::O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate.UpdateCertificate>
{
    private readonly IRepository<CertificateEntity> _groupsRepository;
    private readonly IQueryHandler<CertificateQuery, CertificateEntity> _userGroupQueryHandler;

    public UpdateCertificateDetailsCommandHandler(
        IQueryHandler<CertificateQuery, CertificateEntity> userGroupQueryHandler,
        IRepository<CertificateEntity> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
    }

    public async Task<global::O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate.UpdateCertificate> Handle(UpdateCertificateDetailsCommand request,
        CancellationToken cancellationToken)
    {
        var certificate = await _userGroupQueryHandler.HandleAsync(
            new CertificateQuery(
                request.ExternalId,
                request.IsDeleted,
                request.CustomerId,
                request.ExpiredDate,
                request.PublishDate,
                request.CreatorId,
                request.PublishCode,
                request.IsVisible,
                request.CategoryId,
                request.CategoryEntity,
                request.Lock,
                request.LockedDate,
                request.LockInfo,
                request.LanguageInfos),
            cancellationToken);

        if (certificate is null) return null;

        certificate.ExternalId = request.ExternalId;
        certificate.IsDeleted = request.IsDeleted;
        certificate.CustomerId = request.CustomerId;
        certificate.ExpiredDate = request.ExpiredDate;
        certificate.PublishDate = request.PublishDate;
        certificate.CreatorId = request.CreatorId;
        certificate.PublishCode = request.PublishCode;
        certificate.IsVisible = request.IsVisible;
        certificate.CategoryId = request.CategoryId;
        certificate.CategoryEntity = request.CategoryEntity;
        certificate.Lock = request.Lock;
        certificate.LockedDate = request.LockedDate;
        certificate.LockInfo = request.LockInfo;
        certificate.LanguageInfos = request.LanguageInfos;


        await _groupsRepository.UpdateAsync(certificate, cancellationToken);

        return new global::O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate.UpdateCertificate(
            certificate.Id,
            certificate.ExternalId,
            certificate.ModifiedDate,
            certificate.AddedDate,
            certificate.DeletedDate,
            certificate.IsDeleted,
            certificate.OwnerAccountId,
            certificate.CustomerId,
            certificate.ExpiredDate,
            certificate.PublishDate,
            certificate.CreatorId,
            certificate.PublishCode,
            certificate.IsVisible,
            certificate.CategoryId,
            certificate.CategoryEntity,
            certificate.Lock,
            certificate.LockedDate,
            certificate.LockInfo,
            certificate.LanguageInfos);
    }
}