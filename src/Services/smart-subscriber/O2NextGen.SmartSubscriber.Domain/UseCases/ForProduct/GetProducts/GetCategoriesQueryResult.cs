namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.GetProducts;

public class GetCategoriesQueryResult
{
    public GetCategoriesQueryResult(IReadOnlyCollection<ProductViewModel> categories)
    {
        Categories = categories;
    }

    public IReadOnlyCollection<ProductViewModel> Categories { get; }

    public class ProductViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; }
        public string CustomerId { get; }
        public string ProductCode { get; }

        public ProductViewModel(long id, string productName, string productDescription, string customerId,
            string productCode)
        {
            Id = id;
            ProductName = productName;
            ProductDescription = productDescription;
            CustomerId = customerId;
            ProductCode = productCode;
        }

        public string ProductDescription { get; set; }
    }
}