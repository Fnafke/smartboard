using SmartboardApi.Modules.AuthModule.Models;

namespace SmartboardApi.Modules.AuthModule.Repositories.UserRepository
{
    public interface IUserRepository
    {   
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
    }
}
