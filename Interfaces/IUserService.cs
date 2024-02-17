using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User newUser);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> UpdateUserAsync(string id, User updatedUser);
        Task<User> DeleteUserAsync(string id);
    }
}