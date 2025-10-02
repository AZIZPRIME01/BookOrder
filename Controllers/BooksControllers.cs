using Microsoft.AspNetCore.Mvc;
using BookOrder.Services;
using BookOrder.Dtos;

namespace BookOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // URL = /api/books
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        // Constructor DI
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        // GET: api/books/{Id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var book = await _bookService.GetByIdAsync(Id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var book = await _bookService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = book.Id }, book);
        }

        // PUT: api/books/{Id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateBookDto dto)
        {
            var book = await _bookService.UpdateAsync(Id, dto);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // DELETE: api/books/{Id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var success = await _bookService.DeleteAsync(Id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
