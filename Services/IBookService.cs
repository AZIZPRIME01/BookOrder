
using BookOrder.Dtos;


namespace BookOrder.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BooksDto>> GetAllAsync();
        Task<BooksDto?> GetByIdAsync(int id);
        Task<BooksDto> CreateAsync(CreateBookDto dto);
        Task<BooksDto?> UpdateAsync(int id, UpdateBookDto dto);
        Task<bool> DeleteAsync(int id);
    }
}