using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Queries;

public class GetProductTypesQuery : IRequest<IEnumerable<ProductTypeResponse>>;

public class GetProductTypesQueryHandler(IRepositoryProvider repositoryProvider, IMapper mapper) : IRequestHandler<GetProductTypesQuery, IEnumerable<ProductTypeResponse>>
{
    protected readonly IRepositoryProvider repositoryProvider = Throw.IfNull(repositoryProvider);
    protected readonly IMapper mapper = Throw.IfNull(mapper);

    public Task<IEnumerable<ProductTypeResponse>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
    {
        IRepository<ProductType> repository = repositoryProvider.GetRepository<ProductType>();

        IEnumerable<ProductType> productTypes = repository.Entities.AsNoTracking();

        return Task.FromResult(mapper.Map<IEnumerable<ProductTypeResponse>>(productTypes));
    }
}
