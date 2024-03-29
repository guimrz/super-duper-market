using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper) : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        protected readonly IRepository<Product> repository = Throw.IfNull(repository);
        protected readonly IMapper mapper = Throw.IfNull(mapper);

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new (request.Name);

            product = await repository.InsertAsync(product, cancellationToken);

            await repository.SaveChangesAsync(cancellationToken);

            return mapper.Map<ProductResponse>(product);
        }
    }
}
