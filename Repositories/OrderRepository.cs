using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(DataContext context) : base()
        {
            _context = context;
        }
        private readonly DataContext _context;

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<List<Order>> GetOrdersAsync(int Id)
        {
            return await _context.Orders.Where(order => order.Id == Id).ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(int Id, Order updatedOrder)
        {
            Order existingOrder = await _context.Orders.FirstOrDefaultAsync(order => order.Id == Id);

            if (existingOrder != null)
            {
                existingOrder.Id = updatedOrder.Id;
                existingOrder.CustomerId = updatedOrder.CustomerId;
                existingOrder.Amount = updatedOrder.Amount;
                existingOrder.OrderDate = updatedOrder.OrderDate;

                await _context.SaveChangesAsync();
            }

            return existingOrder;
        }

        public async Task RemoveOrderAsync(int Id)
        {
            Order orderToRemove = await _context.Orders.FirstOrDefaultAsync(order => order.Id == Id);

            if (orderToRemove != null)
            {
                _context.Orders.Remove(orderToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
