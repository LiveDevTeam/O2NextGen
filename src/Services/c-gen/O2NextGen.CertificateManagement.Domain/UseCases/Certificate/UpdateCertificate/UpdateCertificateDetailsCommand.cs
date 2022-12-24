using System;
using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.UpdateCertificate
{
    public class UpdateCertificateDetailsCommand: IRequest<UpdateCertificateDetailsCommandResult>
    {
        public UpdateCertificateDetailsCommand(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; }
    }
}

