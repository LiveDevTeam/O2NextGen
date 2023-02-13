namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories;

public class GetCategoriesQueryResult
{
    public GetCategoriesQueryResult(IReadOnlyCollection<CategoryViewModel> categories)
    {
        Categories = categories;
    }

    public IReadOnlyCollection<CategoryViewModel> Categories { get; }

    public class CategoryViewModel
    {
        public CategoryViewModel(long id, string categoryName, string categoryDescription,
            string categorySeries, int quantityCertificates)
        {
            Id = id;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
            CategorySeries = categorySeries;
            QuantityCertificates = quantityCertificates;
        }

        public long Id { get; set; }
        public string CategoryName { get; }
        public string CategoryDescription { get; }
        public string CategorySeries { get; }
        public int QuantityCertificates { get; }
    }
}