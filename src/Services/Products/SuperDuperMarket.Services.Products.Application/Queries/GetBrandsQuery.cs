using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Application.Queries;

public class GetBrandsQuery : IRequest<IEnumerable<BrandResponse>>;

public class GetBrandsQueryHandler(IRepository<Brand> repository, IMapper mapper) : IRequestHandler<GetBrandsQuery, IEnumerable<BrandResponse>>
{
    protected readonly IRepository<Brand> repository = Throw.IfNull(repository);
    protected readonly IMapper mapper = Throw.IfNull(mapper);

    public Task<IEnumerable<BrandResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Brand> brands = repository.Entities.AsNoTracking();

        return Task.FromResult(mapper.Map<IEnumerable<BrandResponse>>(brands));
    }
}