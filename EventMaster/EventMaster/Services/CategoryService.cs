using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategoryAsync(CategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<Category?> UpdateCategoryAsync(int id, CategoryDTO dto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null) return null;

            existingCategory.Name = dto.Name;
            _categoryRepository.Update(existingCategory);
            await _categoryRepository.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            _categoryRepository.Remove(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}
