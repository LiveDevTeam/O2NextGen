using System;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.CreateCertificate
{
    public class CreateCertificateCommandResult
    {
        public CreateCertificateCommandResult(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; }
    }
}

