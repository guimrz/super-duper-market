using SuperDuperMarket.Services.Products.Application.Objects.Responses;

namespace SuperDuperMarket.Services.Products.Application.Queries.GetProducts
{
    public class GetProductsQuery(int pageSize = 20, int pageNumber = 1) : IRequest<IEnumerable<ProductResponse>>
    {
        public int PageSize { get; set; } = pageSize;

        public int PageNumber { get; set; } = pageNumber;
    }
}