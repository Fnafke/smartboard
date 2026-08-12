using Microsoft.IdentityModel.Tokens;
using SmartboardApi.Controllers.DTO;
using SmartboardApi.Models;
using SmartboardApi.Repositories.UserRepository;
using SmartboardApi.Services.TokenService;
using System.Security.Authentication;
using BC = BCrypt.Net.BCrypt;

namespace SmartboardApi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService) { 
            _userRepository = userRepository; 
            _tokenService = tokenService;
        }

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
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("Username should not be empty");
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("Email should not be empty.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Password should not be empty.");

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

        public async Task<AuthenticationResponse> AuthenticateUser(string username, string password)
        {
            User? user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null) throw new AuthenticationException("Username or password is incorrect.");
            if (!BC.Verify(password, user.Password)) throw new AuthenticationException("Username or password is incorrect.");

            string token = _tokenService.GenerateToken(user);

            return new AuthenticationResponse(token, user.Username);

        }
    }
}
