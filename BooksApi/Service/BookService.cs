using BooksApi.Model;
using BooksApi.Model.DTOs;
using BooksApi.Model.ViewModel;
using BooksApi.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<IEnumerable<BookDTO>> GetBooksByCategoryId(int categoryId)
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

        public async Task<IEnumerable<BookDTO>> GetBooksByTitle(string title)
        {
            IQueryable<Book> query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(c => c.Title.ToLower().Contains(title.ToLower()));
            }

            var books = await query.Include(b => b.Category).ToListAsync();

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

        public async Task<BookDTO?> CreateBook(CreateBookDTO bookToCreate)
        {
            if (!string.IsNullOrWhiteSpace(bookToCreate.Title) && bookToCreate.Title.Length > 250) return null;
            if (bookToCreate.Img != null && bookToCreate.Img.Length > 2000) return null;
            if (bookToCreate.Author != null && bookToCreate.Author.Length > 100) return null;

            var categoryId = await _context.Categories.FindAsync(bookToCreate.CategoryId);
            if (categoryId == null) return null;
            {
}
            // return null here 

            // missing chek for PublishDate

            var book = new Book
            {
                Title = bookToCreate.Title,
                Img = bookToCreate.Img,
                Author = bookToCreate.Author,
                PublishDate = bookToCreate.PublishDate,
                CategoryId = categoryId.Id,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Img = book.Img,
                Author = book.Author,
                PublishDate = book.PublishDate,
                IsAvailable = book.IsAvailable,
                Category = new CategoryDTO
                {
                    Id = book.Category.Id,
                    Name = book.Category.Name
                },
            };
        }

        public async Task<BookDTO?> GetBookById(int id)
        {
            var book = await _context.Books.Include(b => b.Category).SingleOrDefaultAsync(b => b.Id == id);
            if (book == null) throw new KeyNotFoundException($"No book with id {id} was found");

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Img = book.Img,
                Author = book.Author,
                PublishDate = book.PublishDate,
                IsAvailable = book.IsAvailable,
                Category = new CategoryDTO
                {
                    Id = book.Category.Id,
                    Name = book.Category.Name
                }
            };
        }
    }
}
