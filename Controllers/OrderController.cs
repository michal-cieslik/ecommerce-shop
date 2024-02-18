using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;
using ecommerce_shop.Data;
using ecommerce_shop.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(DataContext context) : base()
        {
            var _orderRepository = new OrderRepository(context);
            _orderService = new OrderService(_orderRepository);
        }
        private readonly OrderService _orderService;

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] Order newOrder)
        {
            newOrder.DateAdded = DateTime.UtcNow;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Order order = await _orderService.AddOrderAsync(newOrder);
            return Ok(order);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync(int userId)
        {
            List<Order> orders = await _orderService.GetOrdersAsync(userId);
            return Ok(orders);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] Order updatedOrder)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Order order = await _orderService.UpdateOrderAsync(id, updatedOrder);
            return Ok(order);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveOrderAsync(int id)
        {
            await _orderService.RemoveOrderAsync(id);
            return Ok();
        }
    }
}