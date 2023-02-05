using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IQueryHandler<CategoryQuery, Entities.Category> _userGroupQueryHandler;
    private readonly IRepository<Entities.Category> groupsRepository;

    public DeleteCategoryCommandHandler(
        IQueryHandler<CategoryQuery, Entities.Category> userGroupQueryHandler,
        IRepository<Entities.Category> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        this.groupsRepository = groupsRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _userGroupQueryHandler.HandleAsync(
            new CategoryQuery(request.Id),
            cancellationToken);

        if (category is object)
        {
            await groupsRepository.DeleteAsync(category, cancellationToken);
        }

        return Unit.Value;
    }
}