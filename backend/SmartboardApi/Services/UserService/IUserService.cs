using SmartboardApi.Models;

namespace SmartboardApi.Services.UserService
{
    public interface IUserService
    {
        Task<Boolean> UserExistsByEmailAsync(string email);
        Task<Boolean> UserExistsByUsernameAsync(string username);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(string username, string email, string password);
    }
}
