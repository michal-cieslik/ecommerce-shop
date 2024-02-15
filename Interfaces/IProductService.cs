using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product newProduct);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task DeleteProductAsync(int id);
    }
}