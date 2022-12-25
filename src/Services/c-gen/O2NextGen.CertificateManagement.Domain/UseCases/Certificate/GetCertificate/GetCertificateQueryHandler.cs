using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate
{
    public class GetCertificateQueryHandler :
        IRequestHandler<GetCertificateQuery, GetCertificateQueryResult>
    {
        private readonly IQueryHandler<CertificateQuery, CertificateDbEntity> _queryHandler;

        public GetCertificateQueryHandler(IQueryHandler<CertificateQuery, CertificateDbEntity> queryHandler)
        {
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));

        }

        public async Task<GetCertificateQueryResult> Handle(GetCertificateQuery request, CancellationToken cancellationToken)
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

            //var result = await certificatesService.GetByIdAsync(request.Id, cancellationToken);

            //if (result == null)
            //    throw new Exception("Object not found");

            //return new GetCertificateCommandResult(result.Id, result.Name);
        }
    }
}

