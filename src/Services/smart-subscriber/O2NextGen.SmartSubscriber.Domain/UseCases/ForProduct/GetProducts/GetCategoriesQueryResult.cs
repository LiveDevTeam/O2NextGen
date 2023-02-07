namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.GetCategories;

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
        public string CategoryName { get; }
        public string CategoryDescription { get; }
        public string CategorySeries { get; }
        public int QuantityCertificates { get; }

        public ProductViewModel(long id, string categoryName, string categoryDescription,
            string categorySeries, int quantityCertificates)
        {
            Id = id;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
            CategorySeries = categorySeries;
            QuantityCertificates = quantityCertificates;
        }
    }
}