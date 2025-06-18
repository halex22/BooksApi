using BooksApi.Model.DTOs;
using BooksApi.Model.ViewModel;
using BooksApi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Service
{
    public class BookService: IBookService
    {
        private readonly BooksContext _context;

        public BookService(BooksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var books = await _context.Books.Include(b => b.Category).ToListAsync();
            return books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Img = b.Img,
                Author = b.Author,
                PublishDate = b.PublishDate,
                IsAvailable = b.IsAvailable,
                Category = new CategoryDTO
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                }
            });
        }

        public async Task<IEnumerable<BookDTO>> GetBookByCategoryId(int categoryId)
        {
            var books = await _context.Books.Include(b => b.Category).Where(b => b.Category.Id == categoryId).ToListAsync();
            return books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Img = b.Img,
                Author = b.Author,
                PublishDate = b.PublishDate,
                IsAvailable = b.IsAvailable,
                Category = new CategoryDTO
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                }
            });
        }

        public async Task<BookDTO> CreateBook(CreateBookDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
