using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate
{

    public class GetCertificateQuery : IRequest<GetCertificateQueryResult>
    {
        private long id;

        public GetCertificateQuery(long id)
        {
            this.Id = id;
        }

        public long Id { get => id; set => id = value; }
    }
}

