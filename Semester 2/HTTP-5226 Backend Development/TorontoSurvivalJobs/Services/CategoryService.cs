using Microsoft.EntityFrameworkCore;
using TorontoSurvivalJobs.Data;
using TorontoSurvivalJobs.Models;

namespace TorontoSurvivalJobs.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories
                .Include(c => c.Jobs)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Jobs)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
            {
                return false;
            }

            if (category.Jobs.Any())
            {
                return false;
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}