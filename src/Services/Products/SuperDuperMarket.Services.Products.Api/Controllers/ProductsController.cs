using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMarket.Core;
using SuperDuperMarket.Services.Products.Application.Commands;
using SuperDuperMarket.Services.Products.Application.Objects.Requests;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Application.Queries;

namespace SuperDuperMarket.Services.Products.Api.Controllers
{
    [Route("api/products")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator mediator = Throw.IfNull(mediator);

        [HttpGet]
        [ProducesResponseType<IEnumerable<ProductResponse>>(200)]
        public async Task<IActionResult> GetProductsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(new GetProductsQuery(pageSize, pageNumber), cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType<ProductResponse>(201)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(new CreateProductCommand(request), cancellationToken);

            return new ObjectResult(result);
        }

        [HttpDelete("{productId:guid}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            await mediator.Send(new DeleteProductCommand(productId), cancellationToken);

            return Ok();
        }
    }
}