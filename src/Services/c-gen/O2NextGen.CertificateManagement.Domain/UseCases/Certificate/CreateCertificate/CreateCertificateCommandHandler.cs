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
        private readonly IRepository<CertificateEntity> groupsRepository;

        public CreateCertificateCommandHandler(IRepository<CertificateEntity> groupsRepository)
        {
            this.groupsRepository = groupsRepository;
        }
        public async Task<CreateCertificateCommandResult> Handle(
            CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            var group = new CertificateEntity
            {
                Name = request.Name
            };

            var addedGroup = await groupsRepository.AddAsync(group, cancellationToken);

            return new CreateCertificateCommandResult(
                addedGroup.Id,
                addedGroup.Name);
        }
    }
}

