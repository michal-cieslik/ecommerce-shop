using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Services
{
    public class CartService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<Cart> AddCartItem(Cart newCartItem)
        {
            _context.Carts.Add(newCartItem);
            await _context.SaveChangesAsync();
            return newCartItem;
        }

        public async Task<List<Cart>> GetCartItems(int userId)
        {
            return await _context.Carts.Where(cart => cart.UserId == userId).ToListAsync();
        }

        // Dodaj odpowiednie metody asynchroniczne dla pozostałych operacji, takich jak UpdateCartItem i RemoveCartItem.

        public async Task<Cart> UpdateCartItem(int cartItemId, Cart updatedCartItem)
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

        public async Task RemoveCartItem(int cartItemId)
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