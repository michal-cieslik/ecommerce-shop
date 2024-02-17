using ecommerce_shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Data
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(UserManager<User> userManager, DataContext context) : base()
        {
            _userManager = userManager;
            _context = context;
        }
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public async Task<User> CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var result = await _userManager.CreateAsync(newUser);

            if (result.Succeeded)
            {
                return newUser;
            }
            else
            {
                throw new ApplicationException($"Utworzenie użytkownika nie powiodło się. Błędy: {string.Join(", ", result.Errors)}");
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateUserAsync(string id, User updatedUser)
        {
            var existingUser = await _userManager.FindByIdAsync(id);

            if (existingUser == null)
            {
                throw new ApplicationException($"Użytkownik o ID {id} nie został znaleziony.");
            }

            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;

            var result = await _userManager.UpdateAsync(existingUser);

            if (!result.Succeeded) 
            {
                throw new ApplicationException($"Błąd podczas aktualizacji użytkownika: {string.Join(", ", result.Errors)}");
            }

            return existingUser;
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}