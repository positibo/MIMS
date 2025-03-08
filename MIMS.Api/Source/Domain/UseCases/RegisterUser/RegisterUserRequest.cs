using System.ComponentModel.DataAnnotations;

namespace MIMS.Api.Source.Domain.UseCases.RegisterUser
{
    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
