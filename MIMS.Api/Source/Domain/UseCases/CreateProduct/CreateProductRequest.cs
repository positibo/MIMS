using System.ComponentModel.DataAnnotations;

namespace MIMS.Api.Source.Domain.UseCases.CreateProduct
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductName { get; set; }
    }
}
