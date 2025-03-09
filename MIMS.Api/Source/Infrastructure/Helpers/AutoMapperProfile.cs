using AutoMapper;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Domain.UseCases.V1.CreateProduct;

namespace MIMS.Api.Source.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, Domain.UseCases.V1.GetAllProducts.GetAllProductsResponse>();
            CreateMap<Product, Domain.UseCases.V2.GetAllProducts.GetAllProductsResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductResponse>();
        }
    }
}
