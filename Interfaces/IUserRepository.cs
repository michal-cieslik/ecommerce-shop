using ecommerce_shop.Models;

namespace ecommerce_shop.Data
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User newUser);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> UpdateUserAsync(int id, User updatedUser);
        Task DeleteUserAsync(int id);
    }
}