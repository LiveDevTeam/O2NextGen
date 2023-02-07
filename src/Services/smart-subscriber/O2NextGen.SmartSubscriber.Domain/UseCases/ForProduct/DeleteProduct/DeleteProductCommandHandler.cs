using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.DeleteCategory;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IQueryHandler<ProductQuery, Entities.Product> _userGroupQueryHandler;
    private readonly IRepository<Entities.Product> groupsRepository;

    public DeleteProductCommandHandler(
        IQueryHandler<ProductQuery, Entities.Product> userGroupQueryHandler,
        IRepository<Entities.Product> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        this.groupsRepository = groupsRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _userGroupQueryHandler.HandleAsync(
            new ProductQuery(request.Id),
            cancellationToken);

        if (category is object)
        {
            await groupsRepository.DeleteAsync(category, cancellationToken);
        }

        return Unit.Value;
    }
}