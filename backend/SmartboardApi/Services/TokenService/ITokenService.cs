using SmartboardApi.Models;

namespace SmartboardApi.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
