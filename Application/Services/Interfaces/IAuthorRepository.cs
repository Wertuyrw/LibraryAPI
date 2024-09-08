using Domain.Entity;

namespace Application.Services.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> ReadAllAsync();

        Task<Author?> CreateAsync(Author newAuthor, CancellationToken cancellationToken = default);
        Task<Author?> UpdateAsync(int id, Author newAuthor, CancellationToken cancellationToken = default);
        Task<Author?> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Author?> ReadAsync(int id, CancellationToken cancellationToken = default);
    }
}
