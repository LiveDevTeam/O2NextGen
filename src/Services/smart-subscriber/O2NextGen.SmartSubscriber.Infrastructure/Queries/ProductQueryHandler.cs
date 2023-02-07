using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Infrastructure.Data;

namespace O2NextGen.SmartSubscriber.Infrastructure.Queries;

public class ProductQueryHandler : IQueryHandler<ProductQuery, Product>
{
    private readonly ApplicationDbContext context;

    public ProductQueryHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<Product> HandleAsync(ProductQuery query, CancellationToken ct)
    {
        var result = await context.Set<Product>().FindAsync(new object[] { query.Id }, ct);
        return result;
    }

}