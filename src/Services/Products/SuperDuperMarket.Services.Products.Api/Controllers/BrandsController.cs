using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMarket.Core;
using SuperDuperMarket.Services.Products.Application.Objects.Responses;
using SuperDuperMarket.Services.Products.Application.Queries;
using System.Net;

namespace SuperDuperMarket.Services.Products.Api.Controllers
{
    [Route("api/brands")]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator mediator = Throw.IfNull(mediator);

        [HttpGet]
        [ProducesResponseType<IEnumerable<BrandResponse>>((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrandsAsync(CancellationToken cancellationToken = default)
        {
            var brands = await mediator.Send(new GetBrandsQuery(), cancellationToken);

            return new ObjectResult(brands);
        }
    }
}