using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface ICartService
    {
        Task<Cart> AddCartItemAsync(Cart newCartItem);
        Task<List<Cart>> GetCartItemsAsync(string userId);
        Task<Cart> UpdateCartItemAsync(int cartItemId, Cart updatedCartItem);
        Task RemoveCartItemAsync(int cartItemId);
    }
}