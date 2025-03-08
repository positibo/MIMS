using AutoMapper;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Domain.UseCases.CreateProduct;
using MIMS.Api.Source.Domain.UseCases.GetAllProducts;

namespace MIMS.Api.Source.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetAllProductsResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductResponse>();
        }
    }
}
