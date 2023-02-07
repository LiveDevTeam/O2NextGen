using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;
using O2NextGen.SmartSubscriber.Domain.Mappings;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.GetSubscriptions;

public class GetSubscriptionsQueryHandler
    : IRequestHandler<GetSubscriptionsQuery, GetSubscriptionsQueryResult>
{
    private readonly IQueryHandler<CertificatesQuery, IReadOnlyCollection<Subscription>> queryHandler;

    public GetSubscriptionsQueryHandler(
        IQueryHandler<CertificatesQuery, IReadOnlyCollection<Subscription>> queryHandler)
    {
        this.queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    public async Task<GetSubscriptionsQueryResult> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var certificates = await queryHandler.HandleAsync(
            new CertificatesQuery(),
            cancellationToken);

        return new GetSubscriptionsQueryResult(
            certificates.MapAsReadOnly(certificate =>
                new GetSubscriptionsQueryResult.CertificateViewModel(
                    certificate.Id,
                    certificate.ExternalId,
                    certificate.ModifiedDate,
                    certificate.AddedDate,
                    certificate.DeletedDate,
                    certificate.IsDeleted,
                    certificate.OwnerAccountId,
                    certificate.CustomerId,
                    certificate.ExpiredDate,
                    certificate.StartedDate,
                    certificate.CreatorId,
                    certificate.PublishCode,
                    certificate.IsVisible,
                    certificate.ProductId,
                    certificate.Product,
                    certificate.Lock,
                    certificate.LockedDate,
                    certificate.LockInfo)));
    }
}