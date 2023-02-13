using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.UpdateCategory;

public class UpdateCategoryDetailsCommandHandler
    : IRequestHandler<UpdateCategoryDetailsCommand, UpdateCategoryDetailsCommandResult>
{
    private readonly IRepository<Category> _groupsRepository;
    private readonly IQueryHandler<CategoryQuery, Category> _userGroupQueryHandler;

    public UpdateCategoryDetailsCommandHandler(
        IQueryHandler<CategoryQuery, Category> userGroupQueryHandler,
        IRepository<Category> groupsRepository)
    {
        _userGroupQueryHandler =
            userGroupQueryHandler ?? throw new ArgumentNullException(nameof(userGroupQueryHandler));
        _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
    }

    public async Task<UpdateCategoryDetailsCommandResult> Handle(UpdateCategoryDetailsCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _userGroupQueryHandler.HandleAsync(
            new CategoryQuery(
                request.Id
            ),
            cancellationToken);

        if (category is null) return null;


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