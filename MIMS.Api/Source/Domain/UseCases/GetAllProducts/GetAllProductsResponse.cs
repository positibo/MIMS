using MIMS.Api.Source.Domain.Entiities;

namespace MIMS.Api.Source.Domain.UseCases.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public List<Packaging> Packagings { get; set; } = new List<Packaging>();
    }
}
