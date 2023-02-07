using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Data.Queries;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.UpdateProduct;

public class UpdateProductDetailsCommandHandler
    : IRequestHandler<UpdateProductDetailsCommand, UpdateProductDetailsCommandResult>
{
    private readonly IQueryHandler<ProductQuery, Entities.Product> _userGroupQueryHandler;
    private readonly IRepository<Entities.Product> _groupsRepository;

    public UpdateProductDetailsCommandHandler(
        IQueryHandler<ProductQuery, Entities.Product> userGroupQueryHandler,
        IRepository<Entities.Product> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
    }

    public async Task<UpdateProductDetailsCommandResult> Handle(UpdateProductDetailsCommand request,
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
        category.ProductName = request.ProductName;
        
        category.ProductName = request.ProductName;
        
        
        category.ProductDescription = request.ProductDescription;
        category.ProductCode = request.ProductCode;

        await _groupsRepository.UpdateAsync(category, cancellationToken);

        return new UpdateProductDetailsCommandResult(
            category.Id,
            category.ModifiedDate,
            category.AddedDate,
            category.DeletedDate,
            category.IsDeleted,
            category.CustomerId,
            category.ProductName,
            category.ProductDescription,
            category.ProductCode
        );
    }
}