namespace O2NextGen.CertificateManagement.Domain.Data.Queries
{
    public class CategoryQuery : IQuery<Entities.Category>
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public int QuantityCertificates { get; set; }
        public string CategoryDescription { get; set; }
        public string CategorySeries { get; set; }

        public CategoryQuery(long id)
        {
            Id = id;
        }

    }
}

