using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Application.Features.Brands.Commands.CreateBrand;
using OnionApi.Application.Features.Brands.Queries.GetAllBrands;
using OnionApi.Application.Features.Products.Command.CreateProduct;
using OnionApi.Application.Features.Products.Queries.GetAllProducts;

namespace OnionApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var query = new GetAllBrandsQueryRequest();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
