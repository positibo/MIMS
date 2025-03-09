using System.ComponentModel.DataAnnotations;

namespace MIMS.Api.Source.Domain.UseCases.V1.CreateProduct
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductName { get; set; }
    }
}
