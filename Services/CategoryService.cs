using ecommerce_shop.Models;
using ecommerce_shop.Repositories;

namespace ecommerce_shop.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
