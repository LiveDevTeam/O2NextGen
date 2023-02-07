using Microsoft.EntityFrameworkCore;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Infrastructure.Data;

namespace O2NextGen.SmartSubscriber.Infrastructure.Queries;

public class ProductsQueryHandler : IQueryHandler<CategoriesQuery, IReadOnlyCollection<Product>>
{
    private readonly ApplicationDbContext context;

    public ProductsQueryHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<IReadOnlyCollection<Product>> HandleAsync(CategoriesQuery query, CancellationToken ct)
        => (await context
                .Categories
                .ToListAsync(ct))
            .AsReadOnly();
}