using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User newUser);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> UpdateUserAsync(int id, User updatedUser);
        Task DeleteUserAsync(int id);
    }
}