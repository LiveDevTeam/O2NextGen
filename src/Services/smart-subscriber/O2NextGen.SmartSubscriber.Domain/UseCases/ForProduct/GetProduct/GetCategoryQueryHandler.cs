using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.GetCategory;

public class GetCategoryQueryHandler :
    IRequestHandler<GetCategoryQuery, GetCategoryQueryResult>
{
    private readonly IQueryHandler<ProductQuery, Product> _queryHandler;

    public GetCategoryQueryHandler(IQueryHandler<ProductQuery, Product> _queryHandler)
    {
        this._queryHandler = _queryHandler;
    }

    public async Task<GetCategoryQueryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _queryHandler.HandleAsync(
            new ProductQuery(
                request.Id),
            cancellationToken);

        if (category is null)
        {
            return null;
        }

        return new GetCategoryQueryResult(
            id: category.Id,
            modifiedDate: category.ModifiedDate,
            addedDate: category.AddedDate,
            deletedDate: category.DeletedDate,
            isDeleted: category.IsDeleted,
            customerId: category.CustomerId,
            categoryName: category.CategoryName,
            categoryDescription: category.CategoryDescription,
            quantityCertificates: category.QuantityCertificates,
            quantityPublishCode: category.QuantityPublishCode,
            categorySeries: category.CategorySeries);
    }
}