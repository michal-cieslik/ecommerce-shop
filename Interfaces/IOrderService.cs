using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order newOrder);
        Task<List<Order>> GetOrdersAsync(int userId);
        Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder);
        Task RemoveOrderAsync(int orderId);
    }
}
