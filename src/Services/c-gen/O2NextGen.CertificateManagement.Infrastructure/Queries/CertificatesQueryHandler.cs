using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries
{
    public class CertificatesQueryHandler : IQueryHandler<CertificatesQuery, IReadOnlyCollection<CertificateDbEntity>>
    {
        private readonly CertificateManagementDbContext context;

        public CertificatesQueryHandler(CertificateManagementDbContext context)
        {
            this.context = context;
        }
        public async Task<IReadOnlyCollection<CertificateDbEntity>> HandleAsync(CertificatesQuery query, CancellationToken ct)
         => (await context
                .Certificates
                .ToListAsync(ct))
                .AsReadOnly();
    }
}

