using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.GetCertificate;

public sealed class GetSubscriptionQuery : IRequest<GetSubscriptionQueryResult>
{
    private long id;

    public GetSubscriptionQuery(long id)
    {
        Id = id;
    }

    public long Id { get => id; set => id = value; }
}