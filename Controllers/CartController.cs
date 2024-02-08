using ecommerce_shop.Models;
using ecommerce_shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(CartService cartService) : ControllerBase
    {
        private readonly CartService _cartService = cartService;

        [HttpPost]
        public async Task<ActionResult<Cart>> AddCartItem(Cart newCartItem)
        {
            return await _cartService.AddCartItem(newCartItem);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Cart>>> GetCartItems(int userId)
        {
            return await _cartService.GetCartItems(userId);
        }

        [HttpPut("{cartItemId}")]
        public async Task<ActionResult<Cart>> UpdateCartItem(int cartItemId, Cart updatedCartItem)
        {
            return await _cartService.UpdateCartItem(cartItemId, updatedCartItem);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> RemoveCartItem(int cartItemId)
        {
            await _cartService.RemoveCartItem(cartItemId);
            return Ok();
        }
    }
}
