using SmartboardApi.Modules.AuthModule.Models;

namespace SmartboardApi.Modules.AuthModule.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
