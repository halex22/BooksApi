using BooksApi;
using BooksApi.Model;
using BooksApi.Model.DTOs;
using BooksApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        //// GET: api/Books/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBook(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        // GET: api/Books/by-category/{id}
        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetBooksByCategoryId([FromRoute] int id)
        {
            var books = await _bookService.GetBooksByCategoryId(id);
            return Ok(books);
        }

        // GET: api/Books/by-title?title=
        [HttpGet("by-title")]
        public async Task<IActionResult> GetBooksByTitle([FromQuery] string title)
        {
            var result = await _bookService.GetBooksByTitle(title);
            if (result == null || !result.Any()) return NotFound($"No books found with the specified title '{title}'");
            return Ok(result);
        }

        //// PUT: api/Books/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(int id, Book book)
        //{
        //    if (id != book.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] CreateBookDTO book)
        {
            var createdBook = await _bookService.CreateBook(book);
            if (createdBook != null) return BadRequest("Book could not be created, invalid data provided");
            return CreatedAtAction("GetBook", createdBook);
        }

        //// DELETE: api/Books/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBook(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.Id == id);
        //}
    }
}
