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

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            return await _userRepository.UpdateUserAsync(id, updatedUser);
        }

        public Task DeleteUserAsync(int id)
        {
            return _userRepository.DeleteUserAsync(id);
        }
    }
}