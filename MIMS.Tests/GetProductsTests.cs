using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Domain.UseCases.V2.GetAllProducts;
using MIMS.Api.Source.Infrastructure.Data;
using MIMS.Api.Source.Infrastructure.Helpers;
using static MIMS.Api.Source.Domain.UseCases.V1.GetAllProducts.GetAllProductsQuery;

namespace MIMS.Tests
{
    public class GetProductsTests
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly GetAllProductsQueryHandler handler;

        public GetProductsTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "MIMSDatabase")
                .Options;

            context = new DataContext(options);
            mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())).CreateMapper();
            handler = new GetAllProductsQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ReturnsProducts()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Product1"
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            // Act
            var result = await handler.Handle(new MIMS.Api.Source.Domain.UseCases.V1.GetAllProducts.GetAllProductsQuery(), CancellationToken.None);

            // Assert
            result.Should().HaveCount(1);
            result[0].ProductName.Should().Be("Product1");
        }
    }
}