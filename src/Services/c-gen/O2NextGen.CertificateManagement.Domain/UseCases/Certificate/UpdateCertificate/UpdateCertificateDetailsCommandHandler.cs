using System.Text.RegularExpressions;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.UpdateCertificate
{
    public class UpdateCertificateDetailsCommandHandler
        : IRequestHandler<UpdateCertificateDetailsCommand, UpdateCertificateDetailsCommandResult>
    {
        private readonly IQueryHandler<CertificateQuery, CertificateEntity> _userGroupQueryHandler;
        private readonly IRepository<CertificateEntity> _groupsRepository;

        public UpdateCertificateDetailsCommandHandler(
            IQueryHandler<CertificateQuery, CertificateEntity> userGroupQueryHandler,
            IRepository<CertificateEntity> groupsRepository)
        {
            _userGroupQueryHandler =
                userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
            _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
        }

        public async Task<UpdateCertificateDetailsCommandResult> Handle(UpdateCertificateDetailsCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _userGroupQueryHandler.HandleAsync(
                new CertificateQuery(request.Id),
                cancellationToken);

            if (certificate is null)
            {
                return null;
            }

            certificate.Name = request.Name;
           
            await _groupsRepository.UpdateAsync(certificate, cancellationToken);

            return new UpdateCertificateDetailsCommandResult(
                certificate.Id,
                certificate.Name);
        }
    }
}

