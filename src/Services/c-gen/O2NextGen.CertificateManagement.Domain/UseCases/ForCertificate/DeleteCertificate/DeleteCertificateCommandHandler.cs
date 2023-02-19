using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.DeleteCertificate;

public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, Unit>
{
    private readonly IQueryHandler<CertificateQuery, CertificateEntity> _userGroupQueryHandler;
    private readonly IRepository<CertificateEntity> groupsRepository;

    public DeleteCertificateCommandHandler(
        IQueryHandler<CertificateQuery, CertificateEntity> userGroupQueryHandler,
        IRepository<CertificateEntity> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        this.groupsRepository = groupsRepository;
    }

    public async Task<Unit> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
    {
        var certificate = await _userGroupQueryHandler.HandleAsync(
            new CertificateQuery(request.Id),
            cancellationToken);

        if (certificate is object) await groupsRepository.DeleteAsync(certificate, cancellationToken);

        return Unit.Value;
    }
}