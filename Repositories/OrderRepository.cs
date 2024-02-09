using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class OrderRepository(DataContext context) : IOrderRepository
    {
        private readonly DataContext _context = context;

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<List<Order>> GetOrdersAsync(int userId)
        {
            return await _context.Orders.Where(order => order.UserId == userId).ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder)
        {
            Order existingOrder = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId);

            if (existingOrder != null)
            {
                existingOrder.OrderId = updatedOrder.OrderId;
                existingOrder.CustomerId = updatedOrder.CustomerId;
                existingOrder.Amount = updatedOrder.Amount;
                existingOrder.OrderDate = updatedOrder.OrderDate;

                await _context.SaveChangesAsync();
            }

            return existingOrder;
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            Order orderToRemove = await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId);

            if (orderToRemove != null)
            {
                _context.Orders.Remove(orderToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
