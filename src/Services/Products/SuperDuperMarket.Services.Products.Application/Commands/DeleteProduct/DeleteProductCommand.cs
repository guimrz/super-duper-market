namespace SuperDuperMarket.Services.Products.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand(Guid productId) : IRequest
    {
        public Guid ProductId { get; set; } = productId;
    }
}
