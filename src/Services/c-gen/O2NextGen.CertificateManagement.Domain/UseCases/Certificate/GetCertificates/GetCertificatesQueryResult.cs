using System.Text.RegularExpressions;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate
{
    public class GetCertificatesQueryResult
    {
        public GetCertificatesQueryResult(IReadOnlyCollection<Certificate> certificates)
        {
            Certificates = certificates;
        }

        public IReadOnlyCollection<Certificate> Certificates { get; }


        public class Certificate
        {
            public Certificate(long id, string name)
            {
                Id = id;
                Name = name;
            }
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}