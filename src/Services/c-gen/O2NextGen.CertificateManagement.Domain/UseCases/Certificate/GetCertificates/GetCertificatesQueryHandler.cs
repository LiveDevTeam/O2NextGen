using System;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Domain.Mappings;
using O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificates
{
    public class GetCertificatesQueryHandler
        : IRequestHandler<GetCertificatesQuery, GetCertificatesQueryResult>
    {
        private readonly IQueryHandler<CertificatesQuery, IReadOnlyCollection<CertificateEntity>> queryHandler;

        public GetCertificatesQueryHandler(
            IQueryHandler<CertificatesQuery, IReadOnlyCollection<CertificateEntity>> queryHandler)
        {
            this.queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
        }

        public async Task<GetCertificatesQueryResult> Handle(GetCertificatesQuery request, CancellationToken cancellationToken)
        {
            var certificates = await queryHandler.HandleAsync(
                new CertificatesQuery(),
                cancellationToken);

            return new GetCertificatesQueryResult(
                certificates.MapAsReadOnly(g =>
                        new GetCertificatesQueryResult.Certificate(
                            g.Id,
                            g.Name)));
        }
    }
}

