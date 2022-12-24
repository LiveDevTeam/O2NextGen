using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.CreateCertificate
{
    public class CreateCertificateCommand : IRequest<CreateCertificateCommandResult>
    {
        public string Name { get;  set; }

        public CreateCertificateCommand(string name)
        {
            Name = name;
        }
    }
}

