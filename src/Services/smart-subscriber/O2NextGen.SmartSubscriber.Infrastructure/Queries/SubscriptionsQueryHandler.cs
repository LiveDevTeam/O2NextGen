using Microsoft.EntityFrameworkCore;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Infrastructure.Data;

namespace O2NextGen.SmartSubscriber.Infrastructure.Queries;

public class SubscriptionsQueryHandler : IQueryHandler<CertificatesQuery, IReadOnlyCollection<Subscription>>
{
    private readonly ApplicationDbContext context;

    public SubscriptionsQueryHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<IReadOnlyCollection<Subscription>> HandleAsync(CertificatesQuery query, CancellationToken ct)
        => (await context
                .Certificates
                .ToListAsync(ct))
            .AsReadOnly();
}