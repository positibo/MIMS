using MIMS.Api.Source.Domain.Entiities;

namespace MIMS.Api.Source.Infrastructure.Helpers
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
