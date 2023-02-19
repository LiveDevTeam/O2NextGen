using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.CreateCertificate;

public class CreateCertificateCommandHandler
    : IRequestHandler<CreateCertificateCommand, CreateCertificateCommandResult>
{
    private readonly IRepository<Certificate> certificatesRepository;

    public CreateCertificateCommandHandler(IRepository<Certificate> certificatesRepository)
    {
        this.certificatesRepository = certificatesRepository;
    }

    public async Task<CreateCertificateCommandResult> Handle(
        CreateCertificateCommand request, CancellationToken cancellationToken)
    {
        var certificate = new Certificate
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