using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public DeleteCategoryCommand(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}