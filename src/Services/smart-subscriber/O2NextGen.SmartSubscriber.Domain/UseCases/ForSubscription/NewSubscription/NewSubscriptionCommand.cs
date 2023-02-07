using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.NewCertificate;

public class NewSubscriptionCommand : IRequest<NewSubscriptionCommandResult>
{
    public NewSubscriptionCommand(string userId, long productId, int languageId, string customerId)
    {
        UserId = userId;
        ProductId = productId;
        LanguageId = languageId;
        CustomerId = customerId;
    }

    public string UserId { get; }
    public long ProductId { get; }
    public int LanguageId { get; }
    public string CustomerId { get; }
}