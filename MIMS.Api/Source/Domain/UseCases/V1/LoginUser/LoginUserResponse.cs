namespace MIMS.Api.Source.Domain.UseCases.V1.LoginUser
{
    public class LoginUserResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
