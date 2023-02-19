using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Domain.Mappings;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificates;

public class GetCertificatesQueryHandler
    : IRequestHandler<GetCertificatesQuery, GetCertificatesQueryResult>
{
    private readonly IQueryHandler<CertificatesQuery, IReadOnlyCollection<Certificate>> queryHandler;

    public GetCertificatesQueryHandler(
        IQueryHandler<CertificatesQuery, IReadOnlyCollection<Certificate>> queryHandler)
    {
        this.queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    public async Task<GetCertificatesQueryResult> Handle(GetCertificatesQuery request,
        CancellationToken cancellationToken)
    {
        var certificates = await queryHandler.HandleAsync(
            new CertificatesQuery(),
            cancellationToken);

        return new GetCertificatesQueryResult(
            certificates.MapAsReadOnly(certificate =>
                new GetCertificatesQueryResult.CertificateViewModel(
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
                    certificate.Category,
                    certificate.Lock,
                    certificate.LockedDate,
                    certificate.LockInfo,
                    certificate.LanguageInfos)));
    }
}