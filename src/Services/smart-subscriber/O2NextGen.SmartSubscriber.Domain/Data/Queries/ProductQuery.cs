namespace O2NextGen.SmartSubscriber.Domain.Data.Queries;

public class ProductQuery : IQuery<Entities.Product>
{
    public long Id { get; set; }
    public string CategoryName { get; set; }
    public int QuantityCertificates { get; set; }
    public string CategoryDescription { get; set; }
    public string CategorySeries { get; set; }

    public ProductQuery(long id)
    {
        Id = id;
    }

}