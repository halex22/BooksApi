using BooksApi.Model.DTOs;

namespace BooksApi.Service.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<IEnumerable<BookDTO>> GetBookByCategoryId(int categoryId);
        Task<BookDTO> CreateBook(CreateBookDTO book);
    }
}
