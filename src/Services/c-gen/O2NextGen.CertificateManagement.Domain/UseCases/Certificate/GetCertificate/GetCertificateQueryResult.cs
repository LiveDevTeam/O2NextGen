namespace O2NextGen.CertificateManagement.Domain.UseCases.Certificate.GetCertificate
{
    public class GetCertificateQueryResult
    {
        private long id;
        private string name;

        public GetCertificateQueryResult(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}