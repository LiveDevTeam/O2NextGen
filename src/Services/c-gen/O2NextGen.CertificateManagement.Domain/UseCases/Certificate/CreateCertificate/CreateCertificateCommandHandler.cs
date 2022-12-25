using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.CreateCertificate
{
    public class CreateCertificateCommandHandler
        : IRequestHandler<CreateCertificateCommand, CreateCertificateCommandResult>
    {
        private readonly IRepository<CertificateDbEntity> certificatesRepository;

        public CreateCertificateCommandHandler(IRepository<CertificateDbEntity> groupsRepository)
        {
            this.certificatesRepository = groupsRepository;
        }
        public async Task<CreateCertificateCommandResult> Handle(
            CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = new CertificateDbEntity
            {
                ExternalId = request.ExternalId,
                IsDeleted = request.IsDeleted,
                CustomerId = request.CustomerId,
                ExpiredDate = request.ExpiredDate,
                PublishDate = request.PublishDate,
                CreatorId = request.CreatorId,
                PublishCode = request.PublishCode,
                IsVisible = request.IsVisible,
                CategoryId = request.CategoryId,
                Category = request.Category,
                Lock = request.Lock,
                LockedDate = request.LockedDate,
                LockInfo = request.LockInfo,
                LanguageInfos = request.LanguageInfos
            };

            var addedCertificate = await certificatesRepository.AddAsync(certificate, cancellationToken);

            return new CreateCertificateCommandResult(
                addedCertificate.ExternalId,
                addedCertificate.IsDeleted,
                addedCertificate.OwnerAccountId,
                addedCertificate.CustomerId,
                addedCertificate.ExpiredDate,
                addedCertificate.PublishDate,
                addedCertificate.CreatorId,
                addedCertificate.PublishCode,
                addedCertificate.IsVisible,
                addedCertificate.CategoryId,
                addedCertificate.Category,
                addedCertificate.Lock,
                addedCertificate.LockedDate,
                addedCertificate.LockInfo,
                addedCertificate.LanguageInfos);
        }
    }
}

