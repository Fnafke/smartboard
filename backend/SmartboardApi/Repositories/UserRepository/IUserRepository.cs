using SmartboardApi.Models;

namespace SmartboardApi.Repositories.UserRepository
{
    public interface IUserRepository
    {   
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
    }
}
