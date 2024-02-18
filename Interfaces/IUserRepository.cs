using ecommerce_shop.Models;

namespace ecommerce_shop.Data
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User newUser);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> UpdateUserAsync(string id, User updatedUser);
        Task<User> DeleteUserAsync(string id);
    }
}