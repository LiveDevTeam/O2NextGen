using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.UpdateCategory;

public class UpdateCategoryDetailsCommandHandler
    : IRequestHandler<UpdateCategoryDetailsCommand, UpdateCategoryDetailsCommandResult>
{
    private readonly IQueryHandler<ProductQuery, Entities.Product> _userGroupQueryHandler;
    private readonly IRepository<Entities.Product> _groupsRepository;

    public UpdateCategoryDetailsCommandHandler(
        IQueryHandler<ProductQuery, Entities.Product> userGroupQueryHandler,
        IRepository<Entities.Product> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
    }

    public async Task<UpdateCategoryDetailsCommandResult> Handle(UpdateCategoryDetailsCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _userGroupQueryHandler.HandleAsync(
            new ProductQuery(
                request.Id
            ),
            cancellationToken);

        if (category is null)
        {
            return null;
        }

      
        category.IsDeleted = request.IsDeleted;
        category.CustomerId = request.CustomerId;
        category.CategoryName = request.CategoryName;
        
        category.CategoryName = request.CategoryName;
        
        
        category.CategoryDescription = request.CategoryDescription;
        category.QuantityCertificates = request.QuantityCertificates;
        category.CategorySeries = request.CategorySeries;

        await _groupsRepository.UpdateAsync(category, cancellationToken);

        return new UpdateCategoryDetailsCommandResult(
            category.Id,
            category.ModifiedDate,
            category.AddedDate,
            category.DeletedDate,
            category.IsDeleted,
            category.CustomerId,
            category.CategoryName,
            category.CategoryDescription,
            category.QuantityCertificates,
            category.QuantityPublishCode
        );
    }
}