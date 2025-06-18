using BooksApi.Model.DTOs;

namespace BooksApi.Service.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<IEnumerable<BookDTO>> GetBooksByCategoryId(int categoryId);
        Task<IEnumerable<BookDTO>> GetBooksByTitle(string title);
        Task<BookDTO?> CreateBook(CreateBookDTO book);
    }
}
