using MediatR;
using O2NextGen.SmartSubscriber.Domain.Data;
using O2NextGen.SmartSubscriber.Domain.Entities;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.CreateCategory;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    private readonly IRepository<Product> productRepository;

    public CreateProductCommandHandler(IRepository<Entities.Product> productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<CreateProductCommandResult> Handle(
        CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = new Entities.Product
        {
            ProductName = request.ProductName,
            ProductDescription = request.ProductDescription,
            ProductCode = request.ProductCode,
            CustomerId = request.CustomerId,
            AddedDate = request.AddedDate,
            ModifiedDate = request.ModifiedDate,
            DeletedDate = request.DeletedDate,
            IsDeleted = request.IsDeleted
        };

        var addedCertificate = await productRepository.AddAsync(category, cancellationToken);

        return new CreateProductCommandResult(
            addedCertificate.Id,
            addedCertificate.ProductName,
            addedCertificate.ProductDescription,
            addedCertificate.ProductCode,
            addedCertificate.CustomerId,
            addedCertificate.AddedDate,
            addedCertificate.ModifiedDate,
            addedCertificate.DeletedDate,
            addedCertificate.IsDeleted
        );
    }
}