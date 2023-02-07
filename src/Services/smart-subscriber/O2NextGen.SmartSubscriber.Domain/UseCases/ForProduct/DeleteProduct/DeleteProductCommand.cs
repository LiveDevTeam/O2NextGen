
using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public DeleteProductCommand(long id)
    {
        Id = id;
    }
    public long Id { get; set; }
}