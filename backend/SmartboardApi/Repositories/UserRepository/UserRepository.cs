using Microsoft.EntityFrameworkCore;
using SmartboardApi.Data;
using SmartboardApi.Models;

namespace SmartboardApi.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartboardDBContext _dbContext;

        public UserRepository(SmartboardDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user =>  user.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
