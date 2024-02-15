using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;
using ecommerce_shop.Repositories;
using ecommerce_shop.Data;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(DataContext context) : base()
        {
            var _productRepository = new ProductRepository(context);
            _productService = new ProductService(_productRepository);
        }
        private readonly ProductService _productService;

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product newProduct)
        {
            Product product = await _productService.CreateProductAsync(newProduct);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            List<Product> products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            Product product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] Product updatedProduct)
        {
            Product product = await _productService.UpdateProductAsync(id, updatedProduct);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
