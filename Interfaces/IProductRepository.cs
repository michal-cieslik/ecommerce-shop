using ecommerce_shop.Models;

namespace ecommerce_shop.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product newProduct);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task DeleteProductAsync(int id);
    }
}