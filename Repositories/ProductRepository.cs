using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class ProductRepository(DataContext context) : IProductRepository
    {
        private readonly DataContext _context = context;

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return null;

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}