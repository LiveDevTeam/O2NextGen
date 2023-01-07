using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory
{

    public sealed class GetCategoryQuery : IRequest<GetCategoryQueryResult>
    {
        public GetCategoryQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
