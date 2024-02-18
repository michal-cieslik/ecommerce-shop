using ecommerce_shop.Data;
using ecommerce_shop.Models;
using ecommerce_shop.Repositories;
using ecommerce_shop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_shop.Controllers
{
    public class CategoryController : ControllerBase
    {
        public CategoryController(DataContext context) : base()
        {
            var _categoryRepository = new CategoryRepository(context);
            _categoryService = new CategoryService(_categoryRepository);
        }
        private readonly CategoryService _categoryService;

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            List<Category> categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] Category category)
        {
            category.DateAdded = DateTime.UtcNow;
            Category newCategory = await _categoryService.CreateCategoryAsync(category);
            return Ok(newCategory);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] Category category)
        {
            Category updatedCategory = await _categoryService.UpdateCategoryAsync(category);
            return Ok(updatedCategory);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
