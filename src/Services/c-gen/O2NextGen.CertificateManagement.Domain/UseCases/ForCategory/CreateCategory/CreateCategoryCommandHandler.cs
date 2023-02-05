using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly IRepository<Category> categoryRepository;

        public CreateCategoryCommandHandler(IRepository<Entities.Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Entities.Category
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

            var addedCertificate = await categoryRepository.AddAsync(category, cancellationToken);

            return new CreateCategoryCommandResult(
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
}