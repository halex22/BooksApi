using BooksApi.Model.ViewModel;
using BooksApi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly BooksContext _context;

        public CategoryService(BooksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });

        }

        public async Task<CategoryDTO?> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return null;

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
