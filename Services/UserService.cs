using ecommerce_shop.Data;
using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public Task<User> RegisterUserAsync(User newUser)
        {
            return _userRepository.AddUserAsync(newUser);
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            return _userRepository.UpdateUserAsync(id, updatedUser);
        }

        public Task DeleteUserAsync(int id)
        {
            return _userRepository.DeleteUserAsync(id);
        }
    }
}