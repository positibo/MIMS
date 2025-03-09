using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Domain.UseCases.V1.CreateProduct;
using MIMS.Api.Source.Infrastructure.Data;
using MIMS.Api.Source.Infrastructure.Helpers;
using static MIMS.Api.Source.Domain.UseCases.V1.CreateProduct.CreateProductCommand;

namespace MIMS.Tests
{
    public class CreateProductTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly CreateProductCommandHandler handler;

        public CreateProductTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "MIMSDatabase")
                .Options;

            context = new DataContext(options);
            mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())).CreateMapper();
            handler = new CreateProductCommandHandler(context, mapper);
        }

        [Fact]
        public async Task SuccessfullyCreateProduct()
        {
            // Arrange
            var command = new CreateProductCommand(new CreateProductRequest
            {
                ProductName = "Product2"
            });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            var product = await context.Products.FindAsync(result.ProductId);
            product.Should().NotBeNull();
            product.ProductName.Should().Be("Product2");
        }
    }
}
