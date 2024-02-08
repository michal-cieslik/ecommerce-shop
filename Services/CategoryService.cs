using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Services
{
    public class CategoryService(DataContext context)
    {
        private readonly DataContext _dataContext = context;

        public async Task<List<Category>> GetCategories()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _dataContext.Categories.Update(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return false;
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
