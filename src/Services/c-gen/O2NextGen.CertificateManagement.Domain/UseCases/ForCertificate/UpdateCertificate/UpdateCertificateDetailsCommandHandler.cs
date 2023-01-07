using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate
{
    public class UpdateCertificateDetailsCommandHandler
        : IRequestHandler<UpdateCertificateDetailsCommand, UpdateCertificateDetailsCommandResult>
    {
        private readonly IQueryHandler<CertificateQuery, Entities.Certificate> _userGroupQueryHandler;
        private readonly IRepository<Entities.Certificate> _groupsRepository;

        public UpdateCertificateDetailsCommandHandler(
            IQueryHandler<CertificateQuery, Entities.Certificate> userGroupQueryHandler,
            IRepository<Entities.Certificate> groupsRepository)
        {
            _userGroupQueryHandler =
                userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
            _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
        }

        public async Task<UpdateCertificateDetailsCommandResult> Handle(UpdateCertificateDetailsCommand request, CancellationToken cancellationToken)
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
                request.Category,
                request.Lock,
                request.LockedDate,
                request.LockInfo,
                request.LanguageInfos),
                cancellationToken);

            if (certificate is null)
            {
                return null;
            }

            certificate.ExternalId = request.ExternalId;
            certificate.IsDeleted = request.IsDeleted;
            certificate.CustomerId = request.CustomerId;
            certificate.ExpiredDate = request.ExpiredDate;
            certificate.PublishDate = request.PublishDate;
            certificate.CreatorId = request.CreatorId;
            certificate.PublishCode = request.PublishCode;
            certificate.IsVisible = request.IsVisible;
            certificate.CategoryId = request.CategoryId;
            certificate.Category = request.Category;
            certificate.Lock = request.Lock;
            certificate.LockedDate = request.LockedDate;
            certificate.LockInfo = request.LockInfo;
            certificate.LanguageInfos = request.LanguageInfos;


            await _groupsRepository.UpdateAsync(certificate, cancellationToken);

            return new UpdateCertificateDetailsCommandResult(
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

