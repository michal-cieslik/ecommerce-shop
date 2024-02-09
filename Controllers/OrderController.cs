using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderService orderService) : ControllerBase
    {
        private readonly OrderService _orderService = orderService;

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] Order newOrder)
        {
            Order order = await _orderService.AddOrderAsync(newOrder);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync(int userId)
        {
            List<Order> orders = await _orderService.GetOrdersAsync(userId);
            return Ok(orders);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] Order updatedOrder)
        {
            Order order = await _orderService.UpdateOrderAsync(id, updatedOrder);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderAsync(int id)
        {
            await _orderService.RemoveOrderAsync(id);
            return Ok();
        }
    }
}