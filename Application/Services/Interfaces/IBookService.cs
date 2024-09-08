using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookCreateDTO> AddBookAsync(BookCreateDTO bookCreateDto, CancellationToken cancellationToken = default);
        Task<List<BookTakenDTO>> GetBooksAsync();

        Task<BookTakenDTO?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<BookTakenDTO?> GetBookByIsbnAsync(string isbn, CancellationToken cancellationToken = default);
        Task<BookCreateDTO?> UpdateBookAsync(int id, BookCreateDTO bookCreateDto,
        CancellationToken cancellationToken = default);

        Task<BookTakenDTO?> DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
