using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries;

public class CategoryQueryHandler : IQueryHandler<CategoryQuery, Category>
{
    private readonly CGenDbContext context;

    public CategoryQueryHandler(CGenDbContext context)
    {
        this.context = context;
    }

    public async Task<Category> HandleAsync(CategoryQuery query, CancellationToken ct)
    {
        var result = await context.Set<Category>().FindAsync(new object[] {query.Id}, ct);
        return result;
    }
}