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

    public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = new Entities.Product
        {
            CategoryName = request.CategoryName,
            CategoryDescription = request.CategoryDescription,
            CategorySeries = request.CategorySeries,
            CustomerId = request.CustomerId,
            AddedDate = request.AddedDate,
            ModifiedDate = request.ModifiedDate,
            DeletedDate = request.DeletedDate,
            IsDeleted = request.IsDeleted,
            TimeLifeInDays = request.TimeLifeInDays,
            QuantityCertificates = request.QuantityCertificates,
            QuantityPublishCode = request.QuantityPublishCode
        };

        var addedCertificate = await productRepository.AddAsync(category, cancellationToken);

        return new CreateProductCommandResult(
            addedCertificate.Id,
            addedCertificate.CategoryName,
            addedCertificate.CategoryDescription,
            addedCertificate.CategorySeries,
            addedCertificate.CustomerId,
            addedCertificate.AddedDate,
            addedCertificate.ModifiedDate,
            addedCertificate.DeletedDate,
            addedCertificate.IsDeleted,
            addedCertificate.TimeLifeInDays,
            addedCertificate.QuantityCertificates,
            addedCertificate.QuantityPublishCode
        );
    }
}