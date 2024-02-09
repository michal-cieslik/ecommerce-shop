using ecommerce_shop.Models;

namespace ecommerce_shop.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order newOrder);
        Task<List<Order>> GetOrdersAsync(int userId);
        Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder);
        Task RemoveOrderAsync(int orderId);
    }
}
