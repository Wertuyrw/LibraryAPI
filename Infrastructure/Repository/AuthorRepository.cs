using Domain.Entity;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDBContext _context;

        public AuthorRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<Author?> CreateAsync(Author newAuthor, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var author = await _context.AddAsync(newAuthor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return author.Entity;
        }

        public async Task<List<Author>> ReadAllAsync()
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Author?> UpdateAsync(int id, Author newAuthor, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var oldAuthor = await _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (newAuthor == null) return null;

            oldAuthor.FirstName = newAuthor.FirstName;
            oldAuthor.LastName = newAuthor.LastName;

            oldAuthor.BookAuthors = newAuthor.BookAuthors.Select(ba => new BookAuthor
            {
                AuthorId = oldAuthor.Id,
                BookId = ba.BookId
            }).ToList();

            await _context.SaveChangesAsync(cancellationToken);

            return oldAuthor;
        }

        public async Task<Author?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var author = await _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(author => author.Id == id);

            if (author == null) return null;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync(cancellationToken);

            return author;
        }

        public async Task<Author?> ReadAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
