using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Application.Objects.Requests;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Commands;

public class CreateProductCommand(CreateProductRequest request) : IRequest<ProductResponse>
{
    public string Name { get; set; } = Throw.IfNullOrWhiteSpace(request?.Name);

    public string? Description { get; set; } = request.Description;

    public int BrandId { get; set; } = request.BrandId;

    public int ProductTypeId { get; set; } = request.ProductTypeId;

    public int Stock { get; set; } = request.Stock;
}

public class CreateProductCommandHandler(IRepositoryProvider repositoryProvider, IMapper mapper) : IRequestHandler<CreateProductCommand, ProductResponse>
{
    protected readonly IRepositoryProvider repositoryProvider = Throw.IfNull(repositoryProvider);
    protected readonly IMapper mapper = Throw.IfNull(mapper);

    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        IRepository<ProductType> productTypeRepository = repositoryProvider.GetRepository<ProductType>();

        ProductType productType = await productTypeRepository.Entities.SingleOrDefaultAsync(productType => productType.Id == request.ProductTypeId, cancellationToken)
            ?? throw new InvalidOperationException("The specified product type cannot be found.");

        IRepository<Brand> brandRepository = repositoryProvider.GetRepository<Brand>();

        Brand? brand = await brandRepository.Entities.SingleOrDefaultAsync(brand => brand.Id == request.BrandId, cancellationToken)
            ?? throw new InvalidOperationException("The specified brand cannot be found.");

        IRepository<Product> productRepository = repositoryProvider.GetRepository<Product>();

        Product product = new(request.Name, request.Description, request.Stock, brand, productType);

        product = await productRepository.InsertAsync(product, cancellationToken);

        await productRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<ProductResponse>(product);
    }
}