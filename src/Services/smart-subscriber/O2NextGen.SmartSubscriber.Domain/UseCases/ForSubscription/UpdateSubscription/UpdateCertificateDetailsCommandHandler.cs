using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForSubscription.UpdateSubscription;

public class UpdateCertificateDetailsCommandHandler
    : IRequestHandler<UpdateSubscriptionDetailsCommand, UpdateSubscriptionDetailsCommandResult>
{
    private readonly IQueryHandler<CertificateQuery, Entities.Subscription> _userGroupQueryHandler;
    private readonly IRepository<Entities.Subscription> _groupsRepository;

    public UpdateCertificateDetailsCommandHandler(
        IQueryHandler<CertificateQuery, Entities.Subscription> userGroupQueryHandler,
        IRepository<Entities.Subscription> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
    }

    public async Task<UpdateSubscriptionDetailsCommandResult> Handle(UpdateSubscriptionDetailsCommand request, CancellationToken cancellationToken)
    {
        var certificate = await _userGroupQueryHandler.HandleAsync(
            new CertificateQuery(
                request.ExternalId,
                request.IsDeleted,
                request.CustomerId,
                request.ExpiredDate,
                request.PublishDate,
                request.CreatorId,
                request.PublishCode,
                request.IsVisible,
                request.ProductId,
                request.Product,
                request.Lock,
                request.LockedDate,
                request.LockInfo),
            cancellationToken);

        if (certificate is null)
        {
            return null;
        }

        certificate.ExternalId = request.ExternalId;
        certificate.IsDeleted = request.IsDeleted;
        certificate.CustomerId = request.CustomerId;
        certificate.ExpiredDate = request.ExpiredDate;
        certificate.StartedDate = request.PublishDate;
        certificate.CreatorId = request.CreatorId;
        certificate.PublishCode = request.PublishCode;
        certificate.IsVisible = request.IsVisible;
        certificate.ProductId = request.ProductId;
        certificate.Product = request.Product;
        certificate.Lock = request.Lock;
        certificate.LockedDate = request.LockedDate;


        await _groupsRepository.UpdateAsync(certificate, cancellationToken);

        return new UpdateSubscriptionDetailsCommandResult(
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
            certificate.LockInfo);
    }
}