using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Domain.Mappings;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.GetProducts;

public class GetCategoriesQueryHandler
    : IRequestHandler<GetCategoriesQuery, GetCategoriesQueryResult>
{
    private readonly IQueryHandler<CategoriesQuery, IReadOnlyCollection<Product>> queryHandler;

    public GetCategoriesQueryHandler(IQueryHandler<CategoriesQuery, IReadOnlyCollection<Product>> queryHandler)
    {
        this.queryHandler = queryHandler;
    }

    public async Task<GetCategoriesQueryResult> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var certificates = await queryHandler.HandleAsync(
            new CategoriesQuery(),
            cancellationToken);

        return new GetCategoriesQueryResult(
            certificates.MapAsReadOnly(category =>
                new GetCategoriesQueryResult.ProductViewModel(
                    category.Id,
                    category.ProductName,
                    category.ProductDescription,
                    category.CustomerId,
                    category.ProductCode)));


    }
}