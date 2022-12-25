using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.DeleteCertificate
{
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, Unit>
    {
        private readonly IQueryHandler<CertificateQuery, CertificateDbEntity> _userGroupQueryHandler;
        private readonly IRepository<CertificateDbEntity> groupsRepository;

        public DeleteCertificateCommandHandler(
            IQueryHandler<CertificateQuery, CertificateDbEntity> userGroupQueryHandler,
            IRepository<CertificateDbEntity> groupsRepository)
        {
            _userGroupQueryHandler = userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
            this.groupsRepository = groupsRepository;
        }
        public async Task<Unit> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _userGroupQueryHandler.HandleAsync(
                new CertificateQuery(request.Id),
                cancellationToken);

            if (certificate is object)
            {
                await groupsRepository.DeleteAsync(certificate, cancellationToken);
            }

            return Unit.Value;
        }
    }
}

