using ecommerce_shop.Data;
using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        private readonly IUserRepository _userRepository;

        public async Task<User> CreateUserAsync(User newUser)
        {
            return await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(string id, User updatedUser)
        {
            return await _userRepository.UpdateUserAsync(id, updatedUser);
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}