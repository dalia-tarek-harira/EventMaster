using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == categoryName);
        }
    }
}
