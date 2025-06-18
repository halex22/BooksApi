using BooksApi.Model.DTOs;

namespace BooksApi.Service.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO?> GetBookById(int id);
        Task<IEnumerable<BookDTO>> GetBooksByCategoryId(int categoryId);
        Task<IEnumerable<BookDTO>> GetBooksByTitle(string title);
        Task<BookDTO?> CreateBook(CreateBookDTO book);
    }
}
