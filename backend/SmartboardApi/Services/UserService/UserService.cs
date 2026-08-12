using Microsoft.IdentityModel.Tokens;
using SmartboardApi.Models;
using SmartboardApi.Repositories.UserRepository;
using BC = BCrypt.Net.BCrypt;

namespace SmartboardApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { _userRepository = userRepository; }

        public async Task<Boolean> UserExistsByEmailAsync(string email)
        {
            User? user = await _userRepository.GetUserByEmailAsync(email);

            return user != null;
        }

        public async Task<Boolean> UserExistsByUsernameAsync(string username)
        {
            User? user = await _userRepository.GetUserByUsernameAsync(username);

            return user != null;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User? user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new InvalidOperationException("User with this ID does not exist.");
            }

            return user;
        }

        public async Task<User> CreateUserAsync(string username, string email, string password)
        {
            if (username.IsNullOrEmpty()) throw new ArgumentNullException("Username should not be empty");
            if (email.IsNullOrEmpty()) throw new ArgumentNullException("Email should not be empty.");
            if (password.IsNullOrEmpty()) throw new ArgumentNullException("Password should not be empty.");

            if (await UserExistsByUsernameAsync(username))
            {
                throw new InvalidOperationException("A User with this username already exist.");
            }

            if (await UserExistsByEmailAsync(email))
            {
                throw new InvalidOperationException("A User with this email already exists.");
            }

            string passwordHash = BC.HashPassword(password);

            User user = new User(username, email, passwordHash);

            return await _userRepository.CreateUserAsync(user);
        }
    }
}
