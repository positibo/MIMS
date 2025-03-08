namespace MIMS.Api.Source.Domain.Entiities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }
}
