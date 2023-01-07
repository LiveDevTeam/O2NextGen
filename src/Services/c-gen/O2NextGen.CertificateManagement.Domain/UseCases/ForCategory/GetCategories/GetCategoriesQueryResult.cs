using System.Collections.Generic;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories
{

    public class GetCategoriesQueryResult
    {
        public GetCategoriesQueryResult(IReadOnlyCollection<CategoryViewModel> categories)
        {
            Categories = categories;
        }

        public IReadOnlyCollection<CategoryViewModel> Categories { get; }

        public class CategoryViewModel
        {
            public CategoryViewModel()
            {
            }
        }
    }
}