using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class CartRepository : ICartRepository
    {
        public CartRepository(DataContext context) : base()
        {
            _context = context;
        }
        private readonly DataContext _context;

        public async Task<Cart> AddCartItemAsync(Cart newCartItem)
        {
            _context.Carts.Add(newCartItem);
            await _context.SaveChangesAsync();
            return newCartItem;
        }

        public async Task<List<Cart>> GetCartItemsAsync(string userId)
        {
            return await _context.Carts.Where(cart => cart.UserId == userId).ToListAsync();
        }

        public async Task<Cart> UpdateCartItemAsync(int cartItemId, Cart updatedCartItem)
        {
            Cart existingCartItem = await _context.Carts.FindAsync(cartItemId);

            if (existingCartItem != null)
            {
                existingCartItem.DateUpdated = updatedCartItem.DateUpdated;
                existingCartItem.Quantity = updatedCartItem.Quantity;
                await _context.SaveChangesAsync();
            }

            return existingCartItem;
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            Cart cartItem = await _context.Carts.FindAsync(cartItemId);

            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}