using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCertificate.DeleteCertificate;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, Unit>
{
    private readonly IQueryHandler<CertificateQuery, Entities.Subscription> _userGroupQueryHandler;
    private readonly IRepository<Entities.Subscription> groupsRepository;

    public DeleteSubscriptionCommandHandler(
        IQueryHandler<CertificateQuery, Entities.Subscription> userGroupQueryHandler,
        IRepository<Entities.Subscription> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        this.groupsRepository = groupsRepository;
    }

    public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var certificate = await _userGroupQueryHandler.HandleAsync(
            new CertificateQuery(request.Id),
            cancellationToken);

        if (certificate is object)
        {
            await groupsRepository.DeleteAsync(certificate, cancellationToken);
        }

        return Unit.Value;
    }
}