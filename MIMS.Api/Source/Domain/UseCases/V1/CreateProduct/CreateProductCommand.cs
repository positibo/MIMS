using AutoMapper;
using MediatR;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Infrastructure.Data;

namespace MIMS.Api.Source.Domain.UseCases.V1.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public CreateProductRequest CreateProductRequest { get; set; }

        public CreateProductCommand(CreateProductRequest createProductRequest) => CreateProductRequest = createProductRequest;

        private class RequestHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public RequestHandler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<Product>(request.CreateProductRequest);

                context.Products.Add(entity);
                await context.SaveChangesAsync();

                return mapper.Map<CreateProductResponse>(entity);
            }
        }
    }
}
