using ecommerce_shop.Models;
using ecommerce_shop.Repositories;

namespace ecommerce_shop.Services
{
    public class CartService : ICartService
    {
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        private readonly ICartRepository _cartRepository;

        public async Task<Cart> AddCartItemAsync(Cart newCartItem)
        {
            return await _cartRepository.AddCartItemAsync(newCartItem);
        }

        public async Task<List<Cart>> GetCartItemsAsync(string userId)
        {
            return await _cartRepository.GetCartItemsAsync(userId);
        }

        public async Task<Cart> UpdateCartItemAsync(int cartItemId, Cart updatedCartItem)
        {
            return await _cartRepository.UpdateCartItemAsync(cartItemId, updatedCartItem);
        }

        public Task RemoveCartItemAsync(int cartItemId)
        {
            return _cartRepository.RemoveCartItemAsync(cartItemId);
        }
    }
}