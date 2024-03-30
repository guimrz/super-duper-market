using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Commands;

public class DeleteProductCommand(Guid productId) : IRequest
{
    public Guid ProductId { get; set; } = productId;
}

public class DeleteProductCommandHandler(IRepository<Product> repository) : IRequestHandler<DeleteProductCommand>
{
    protected readonly IRepository<Product> repository = Throw.IfNull(repository);

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await repository.Entities.SingleOrDefaultAsync(product => product.Id == request.ProductId, cancellationToken);

        if (product is not null)
        {
            await repository.DeleteAsync(product, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);
        }
    }
}