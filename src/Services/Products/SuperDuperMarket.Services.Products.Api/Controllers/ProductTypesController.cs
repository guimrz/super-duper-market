using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMarket.Core;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Application.Queries;
using System.Net;

namespace SuperDuperMarket.Services.Products.Api.Controllers
{
    [Route("api/product-types")]
    public class ProductTypesController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator mediator = Throw.IfNull(mediator);

        [HttpGet]
        [ProducesResponseType<IEnumerable<ProductTypeResponse>>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductTypesAsync(CancellationToken cancellationToken = default)
        {
            var productTypes = await mediator.Send(new GetProductTypesQuery(), cancellationToken);

            return Ok(productTypes);    
        }
    }
}
