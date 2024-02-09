
using ecommerce_shop.Data;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _dataContext.Categories.Update(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            Category category = await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            return category;
        }
    }
}
