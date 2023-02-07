
using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForCategory.DeleteCategory;

public class DeleteProductCommand : IRequest<Unit>
{
    public DeleteProductCommand(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}