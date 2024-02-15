using ecommerce_shop.Data;
using ecommerce_shop.Models;
using ecommerce_shop.Repositories;

namespace ecommerce_shop.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        private readonly IOrderRepository _orderRepository;

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            return await _orderRepository.AddOrderAsync(newOrder);
        }

        public async Task<List<Order>> GetOrdersAsync(int userId)
        {
            return await _orderRepository.GetOrdersAsync(userId);
        }

        public async Task<Order> UpdateOrderAsync(int orderId, Order updatedOrder)
        {
            return await _orderRepository.UpdateOrderAsync(orderId, updatedOrder);
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            await _orderRepository.RemoveOrderAsync(orderId);
        }
    }
}