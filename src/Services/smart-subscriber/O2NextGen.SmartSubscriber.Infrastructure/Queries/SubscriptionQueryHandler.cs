using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Infrastructure.Data;

namespace O2NextGen.SmartSubscriber.Infrastructure.Queries;

public class SubscriptionQueryHandler : IQueryHandler<CertificateQuery, Subscription>
{
    private readonly ApplicationDbContext context;

    public SubscriptionQueryHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<Subscription> HandleAsync(CertificateQuery query, CancellationToken ct)
    {
        var result = await context.Set<Subscription>().FindAsync(new object[] { query.Id }, ct);
        return result;
    }

}