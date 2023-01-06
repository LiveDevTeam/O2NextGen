using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.DeleteCertificate
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