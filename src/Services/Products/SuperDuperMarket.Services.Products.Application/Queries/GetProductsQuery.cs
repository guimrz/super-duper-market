using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Queries;

public class GetProductsQuery(int pageSize = 20, int pageNumber = 1) : IRequest<IEnumerable<ProductResponse>>
{
    public int PageSize { get; set; } = pageSize;

    public int PageNumber { get; set; } = pageNumber;
}

public class GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper) : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
{
    protected readonly IRepository<Product> repository = Throw.IfNull(repository);
    protected readonly IMapper mapper = Throw.IfNull(mapper);

    public Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = repository.Entities.AsNoTracking()
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize);

        return Task.FromResult(mapper.Map<IEnumerable<ProductResponse>>(products));
    }
}