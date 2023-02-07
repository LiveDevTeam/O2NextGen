namespace O2NextGen.SmartSubscriber.Domain.Data.Queries;

public class ProductQuery : IQuery<Entities.Product>
{
    public long Id { get; set; }
    public string CategoryName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductCode { get; set; }

    public ProductQuery(long id)
    {
        Id = id;
    }

}