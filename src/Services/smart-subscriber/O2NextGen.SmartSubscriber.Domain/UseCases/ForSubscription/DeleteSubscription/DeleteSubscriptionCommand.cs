using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.DeleteSubscription;

public sealed class DeleteSubscriptionCommand : IRequest<Unit>
{
    public DeleteSubscriptionCommand(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}