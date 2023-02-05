using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificate
{

    public class GetCertificateQueryHandler :
        IRequestHandler<GetCertificateQuery, GetCertificateQueryResult>
    {
        private readonly IQueryHandler<CertificateQuery, Certificate> _queryHandler;

        public GetCertificateQueryHandler(IQueryHandler<CertificateQuery, Certificate> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
        }

        public async Task<GetCertificateQueryResult> Handle(GetCertificateQuery request,
            CancellationToken cancellationToken)
        {
            var certificate = await _queryHandler.HandleAsync(
                new CertificateQuery(request.Id),
                cancellationToken);

            if (certificate is null)
            {
                return null;
            }

            return new GetCertificateQueryResult(
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
                certificate.LanguageInfos);
        }
    }
}
