using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Infrastructure.Queries
{
    public class CertificatesQueryHandler : IQueryHandler<CertificatesQuery, IReadOnlyCollection<Certificate>>
    {
        private readonly CGenDbContext context;

        public CertificatesQueryHandler(CGenDbContext context)
        {
            this.context = context;
        }
        public async Task<IReadOnlyCollection<Certificate>> HandleAsync(CertificatesQuery query, CancellationToken ct)
         => (await context
                .Certificates
                .ToListAsync(ct))
                .AsReadOnly();
    }
}

