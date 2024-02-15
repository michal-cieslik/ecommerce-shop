using ecommerce_shop.Models;
using ecommerce_shop.Repositories;

namespace ecommerce_shop.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        private readonly IProductRepository _productRepository;

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await _productRepository.CreateProductAsync(newProduct);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            return await _productRepository.UpdateProductAsync(id, updatedProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}