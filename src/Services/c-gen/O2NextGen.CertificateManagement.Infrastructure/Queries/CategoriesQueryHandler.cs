using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries;

public class CategoriesQueryHandler : IQueryHandler<CategoriesQuery, IReadOnlyCollection<CategoryEntity>>
{
    private readonly CGenDbContext context;

    public CategoriesQueryHandler(CGenDbContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyCollection<CategoryEntity>> HandleAsync(CategoriesQuery query, CancellationToken ct)
    {
        return (await context
                .Categories
                .ToListAsync(ct))
            .AsReadOnly();
    }
}