
using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base()
        {
            _context = context;
        }

        private readonly DataContext _context;

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
