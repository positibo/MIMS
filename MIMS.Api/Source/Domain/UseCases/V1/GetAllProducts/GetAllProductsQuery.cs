using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Infrastructure.Data;

namespace MIMS.Api.Source.Domain.UseCases.V1.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsResponse>>
    {
        private class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public GetAllProductsQueryHandler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await context.Products
                    .ProjectTo<GetAllProductsResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();

                return products;
            }
        }
    }
}
