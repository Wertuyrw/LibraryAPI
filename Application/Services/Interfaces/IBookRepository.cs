using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> CreateAsync(Book newBook, CancellationToken cancellationToken = default);
        Task<List<Book>> ReadAllAsync();
        Task<Book?> ReadByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Book?> ReadByIsbnAsync(string isbn, CancellationToken cancellationToken = default);
        Task<Book?> UpdateAsync(int id, Book newBook, CancellationToken cancellationToken = default);
        Task<Book?> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task AddAuthorToBook(int bookId, List<int> authorIds, CancellationToken cancellationToken = default);
        Task<bool> AuthorExists(int authorId);
    }
}
