using MIMS.Api.Source.Domain.Entiities;

namespace MIMS.Api.Source.Domain.UseCases.V1.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;
    }
}
