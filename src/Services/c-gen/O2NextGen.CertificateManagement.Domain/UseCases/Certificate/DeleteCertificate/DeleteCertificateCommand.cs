using System;
using System.Text.RegularExpressions;
using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.DeleteCertificate
{
    public sealed class DeleteCertificateCommand : IRequest<Unit>
    {
        public DeleteCertificateCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}

