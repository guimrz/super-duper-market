using SuperDuperMarket.Services.Products.Application.Objects.Requests;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;

namespace SuperDuperMarket.Services.Products.Application.Commands.CreateProduct
{
    public class CreateProductCommand(CreateProductRequest request) : IRequest<ProductResponse>
    {
        public string Name { get; set; } = Throw.IfNullOrWhiteSpace(request?.Name);
    }
}
