using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMS.Api.Source.Domain.UseCases.CreateProduct;
using MIMS.Api.Source.Domain.UseCases.GetAllProducts;

namespace MIMS.Api.Source.Domain.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts() => 
            Ok(await mediator.Send(new GetAllProductsQuery()));

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request) =>
            Ok(await mediator.Send(new CreateProductCommand(request)));
    }
}
