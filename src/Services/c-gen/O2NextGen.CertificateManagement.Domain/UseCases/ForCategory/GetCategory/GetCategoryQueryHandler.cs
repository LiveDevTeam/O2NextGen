using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;

public class GetCategoryQueryHandler :
    IRequestHandler<GetCategoryQuery, GetCategoryQueryResult>
{
    private readonly IQueryHandler<CategoryQuery, CategoryEntity> _queryHandler;

    public GetCategoryQueryHandler(IQueryHandler<CategoryQuery, CategoryEntity> _queryHandler)
    {
        this._queryHandler = _queryHandler;
    }

    public async Task<GetCategoryQueryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _queryHandler.HandleAsync(
            new CategoryQuery(
                request.Id),
            cancellationToken);

        if (category is null) return null;

        return new GetCategoryQueryResult(
            category.Id,
            category.ModifiedDate,
            category.AddedDate,
            category.DeletedDate,
            category.IsDeleted,
            category.CustomerId,
            category.CategoryName,
            category.CategoryDescription,
            category.QuantityCertificates,
            category.QuantityPublishCode,
            category.CategorySeries);
    }
}