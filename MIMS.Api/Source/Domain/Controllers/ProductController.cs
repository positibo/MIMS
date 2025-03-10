﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMS.Api.Source.Domain.UseCases.V1.CreateProduct;

namespace MIMS.Api.Source.Domain.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts() => 
            Ok(await mediator.Send(new UseCases.V1.GetAllProducts.GetAllProductsQuery()));

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request) =>
            Ok(await mediator.Send(new CreateProductCommand(request)));
    }
}
