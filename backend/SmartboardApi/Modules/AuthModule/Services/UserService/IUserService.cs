using SmartboardApi.Modules.AuthModule.Controllers.DTO;
using SmartboardApi.Modules.AuthModule.Models;

namespace SmartboardApi.Modules.AuthModule.Services.UserService
{
    public interface IUserService
    {
        Task<Boolean> UserExistsByEmailAsync(string email);
        Task<Boolean> UserExistsByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(string username, string email, string password);
        Task<AuthenticationResponse> AuthenticateUser(string username, string password);
    }
}
