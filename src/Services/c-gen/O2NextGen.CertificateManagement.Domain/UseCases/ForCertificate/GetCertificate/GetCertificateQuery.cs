using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificate;

public sealed class GetCertificateQuery : IRequest<GetCertificateQueryResult>
{
    public GetCertificateQuery(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}