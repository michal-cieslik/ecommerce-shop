using ecommerce_shop.Models;

namespace ecommerce_shop.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
