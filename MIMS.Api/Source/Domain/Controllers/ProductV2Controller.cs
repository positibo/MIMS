using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMS.Api.Source.Domain.UseCases.V1.CreateProduct;

namespace MIMS.Api.Source.Domain.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    public class ProductV2Controller : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductV2Controller(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts() => 
            Ok(await mediator.Send(new UseCases.V2.GetAllProducts.GetAllProductsQuery()));

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request) =>
            Ok(await mediator.Send(new CreateProductCommand(request)));
    }
}
