using BookOrder.Dtos;
using BookOrder.Models;
using BookOrder.Repositories;
namespace BookOrder.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BooksDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.Select(b => new BooksDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = (double)b.Price,
                PublishedDate = b.PublishedDate
            });
        }
        public async Task<BooksDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;

            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = (double)book.Price,
                PublishedDate = book.PublishedDate
            };
        }
        public async Task<BooksDto> CreateAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Price = (double)dto.Price,
                PublishedDate = dto.PublishedDate
            };
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();

            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = (double)book.Price,
                PublishedDate = book.PublishedDate
            };
        }
        public async Task<BooksDto?> UpdateAsync(int id, UpdateBookDto dto)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Price = (double)dto.Price;
            book.PublishedDate = dto.PublishedDate;

            await _repository.UpdateAsync(book);
            await _repository.SaveChangesAsync();

            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = (double)book.Price,
                PublishedDate = book.PublishedDate
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
