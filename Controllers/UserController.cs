using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;
using ecommerce_shop.Data;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserManager<User> userManager, DataContext context) : base()
        {
            var _userRepository = new UserRepository(userManager, context);
            _userService = new UserService(_userRepository);
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User newUser)
        {
            try
            {
                User registeredUser = await _userService.CreateUserAsync(newUser);
                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                List<User> users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            try
            {
                User user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] User updatedUser)
        {
            try
            {
                User user = await _userService.UpdateUserAsync(id, updatedUser);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
