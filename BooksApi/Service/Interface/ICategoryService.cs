using BooksApi.Model.ViewModel;

namespace BooksApi.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO?> GetCategoryById(int id);
        //Task<Category> CreateCategoryAsync(Category category);
        //Task UpdateCategoryAsync(int id, Category category);
        //Task DeleteCategoryAsync(int id);
    }
}
