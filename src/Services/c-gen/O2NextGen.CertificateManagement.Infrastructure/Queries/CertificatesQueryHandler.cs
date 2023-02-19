using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries;

public class CertificatesQueryHandler : IQueryHandler<CertificatesQuery, IReadOnlyCollection<CertificateEntity>>
{
    private readonly CGenDbContext context;

    public CertificatesQueryHandler(CGenDbContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyCollection<CertificateEntity>> HandleAsync(CertificatesQuery query, CancellationToken ct)
    {
        return (await context
                .Certificates
                .ToListAsync(ct))
            .AsReadOnly();
    }
}