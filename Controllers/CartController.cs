using ecommerce_shop.Services;
using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartService cartService) : ControllerBase
    {
        private readonly ICartService _cartService = cartService;

        [HttpPost]
        public async Task<ActionResult<Cart>> AddCartItemAsync(Cart newCartItem)
        {
            return Created("", await _cartService.AddCartItemAsync(newCartItem));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Cart>>> GetCartItemsAsync(int userId)
        {
            return await _cartService.GetCartItemsAsync(userId);
        }

        [HttpPut("{cartItemId:int}")]
        public async Task<ActionResult<Cart>> UpdateCartItemAsync(int cartItemId, [FromBody] Cart updatedCartItem)
        {
            return await _cartService.UpdateCartItemAsync(cartItemId, updatedCartItem);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> RemoveCartItemAsync(int cartItemId)
        {
            await _cartService.RemoveCartItemAsync(cartItemId);
            return Ok();
        }
    }
}