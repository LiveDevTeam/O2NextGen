using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.GetCertificate;

public class GetSubscriptionQueryHandler :
    IRequestHandler<GetSubscriptionQuery, GetSubscriptionQueryResult>
{
    private readonly IQueryHandler<CertificateQuery, Subscription> _queryHandler;

    public GetSubscriptionQueryHandler(IQueryHandler<CertificateQuery, Subscription> queryHandler)
    {
        _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    public async Task<GetSubscriptionQueryResult> Handle(GetSubscriptionQuery request,
        CancellationToken cancellationToken)
    {
        var certificate = await _queryHandler.HandleAsync(
            new CertificateQuery(request.Id),
            cancellationToken);

        if (certificate is null)
        {
            return null;
        }

        return new GetSubscriptionQueryResult(
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
            certificate.LockedDate);
    }
}