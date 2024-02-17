using ecommerce_shop.Services;
using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Data;
using ecommerce_shop.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public CartController(DataContext context) : base()
        {
            var _cartRepository = new CartRepository(context);
            _cartService = new CartService(_cartRepository);
        }
        private readonly CartService _cartService;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Cart>> AddCartItemAsync(Cart newCartItem)
        {
            return Created("", await _cartService.AddCartItemAsync(newCartItem));
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Cart>>> GetCartItemsAsync(string userId)
        {
            return await _cartService.GetCartItemsAsync(userId);
        }

        [Authorize]
        [HttpPut("{cartItemId:int}")]
        public async Task<ActionResult<Cart>> UpdateCartItemAsync(int cartItemId, [FromBody] Cart updatedCartItem)
        {
            return await _cartService.UpdateCartItemAsync(cartItemId, updatedCartItem);
        }

        [Route("delete/{id:int}")]
        [Authorize]
        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> RemoveCartItemAsync(int cartItemId)
        {
            await _cartService.RemoveCartItemAsync(cartItemId);
            return Ok();
        }
    }
}