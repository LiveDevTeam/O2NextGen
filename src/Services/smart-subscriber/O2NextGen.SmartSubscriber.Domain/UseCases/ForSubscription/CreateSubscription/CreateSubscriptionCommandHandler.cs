using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.CreateCertificate;

public class CreateSubscriptionCommandHandler
    : IRequestHandler<CreateSubscriptionCommand, CreateSubscriptionCommandResult>
{
    private readonly IRepository<Entities.Subscription> certificatesRepository;

    public CreateSubscriptionCommandHandler(IRepository<Entities.Subscription> certificatesRepository)
    {
        this.certificatesRepository = certificatesRepository;
    }
    public async Task<CreateSubscriptionCommandResult> Handle(
        CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var certificate = new Entities.Subscription
        {
            ExternalId = request.ExternalId,
            IsDeleted = request.IsDeleted,
            CustomerId = request.CustomerId,
            ExpiredDate = request.ExpiredDate,
            StartedDate = request.PublishDate,
            CreatorId = request.CreatorId,
            PublishCode = request.PublishCode,
            IsVisible = request.IsVisible,
            ProductId = request.ProductId,
            Product = request.Product,
            Lock = request.Lock,
            LockedDate = request.LockedDate
        };

        var addedCertificate = await certificatesRepository.AddAsync(certificate, cancellationToken);

        return new CreateSubscriptionCommandResult(
            addedCertificate.ExternalId,
            addedCertificate.IsDeleted,
            addedCertificate.OwnerAccountId,
            addedCertificate.CustomerId,
            addedCertificate.ExpiredDate,
            addedCertificate.StartedDate,
            addedCertificate.CreatorId,
            addedCertificate.PublishCode,
            addedCertificate.IsVisible,
            addedCertificate.ProductId,
            addedCertificate.Product,
            addedCertificate.Lock,
            addedCertificate.LockedDate);
    }
}