using System.Threading;
using System.Threading.Tasks;
using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory
{

    public class GetCategoryQueryHandler :
        IRequestHandler<GetCategoryQuery, GetCategoryQueryResult>
    {
        private readonly IQueryHandler<CategoryQuery, Category> _queryHandler;

        public GetCategoryQueryHandler(IQueryHandler<CategoryQuery, Category> _queryHandler)
        {
            this._queryHandler = _queryHandler;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var certificate = await _queryHandler.HandleAsync(
                new CategoryQuery(request.Id),
                cancellationToken);

            if (certificate is null)
            {
                return null;
            }

            return new GetCategoryQueryResult(
                certificate.Id,
                certificate.ModifiedDate,
                certificate.AddedDate,
                certificate.DeletedDate,
                certificate.IsDeleted,
                certificate.CustomerId);
        }
    }
}