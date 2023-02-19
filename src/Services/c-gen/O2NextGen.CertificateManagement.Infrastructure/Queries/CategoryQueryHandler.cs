using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries;

public class CategoryQueryHandler : IQueryHandler<CategoryQuery, CategoryEntity>
{
    private readonly CGenDbContext context;

    public CategoryQueryHandler(CGenDbContext context)
    {
        this.context = context;
    }

    public async Task<CategoryEntity> HandleAsync(CategoryQuery query, CancellationToken ct)
    {
        var result = await context.Set<CategoryEntity>().FindAsync(new object[] {query.Id}, ct);
        return result;
    }
}