using System.ComponentModel.DataAnnotations;

namespace MIMS.Api.Source.Domain.UseCases.LoginUser
{
    public class LoginUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
