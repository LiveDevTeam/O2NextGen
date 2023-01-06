using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.DeleteCertificate
{

    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, Unit>
    {
        private readonly IQueryHandler<CertificateQuery, Entities.Certificate> _userGroupQueryHandler;
        private readonly IRepository<Entities.Certificate> groupsRepository;

        public DeleteCertificateCommandHandler(
            IQueryHandler<CertificateQuery, Entities.Certificate> userGroupQueryHandler,
            IRepository<Entities.Certificate> groupsRepository)
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

            if (certificate is object)
            {
                await groupsRepository.DeleteAsync(certificate, cancellationToken);
            }

            return Unit.Value;
        }
    }
}

