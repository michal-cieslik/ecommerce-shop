using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Data
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context) : base()
        {
            _context = context;
        }
        private readonly DataContext _context;

        public async Task<User> CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}