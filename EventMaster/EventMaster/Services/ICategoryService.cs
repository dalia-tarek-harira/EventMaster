using EventMaster.DTOs;
using EventMaster.Models;

namespace EventMaster.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CategoryDTO dto);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<Category?> UpdateCategoryAsync(int id, CategoryDTO dto);
        Task<bool> DeleteCategoryAsync(int id);

    }
}
