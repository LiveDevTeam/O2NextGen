namespace O2NextGen.CertificateManagement.Domain.Data.Queries
{
    public class CategoryQuery : IQuery<Entities.Category>
    {
        public CategoryQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}

