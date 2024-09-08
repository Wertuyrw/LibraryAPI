using Domain.Entity;
using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryDBContext _context;

        public AccountRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetAccountAsync(Account account, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var accountEntity = await _context.Accounts.FirstOrDefaultAsync(
                a => a.Login.ToUpper().Equals(account.Login.ToUpper()), cancellationToken);

            return accountEntity;
        }

        public async Task<Account> RegisterAccountAsync(Account account, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var accountEntity = await _context.Accounts.AddAsync(account);

            await _context.SaveChangesAsync(cancellationToken);

            return accountEntity.Entity;
        }

        public async Task<bool> IsLoginTakenAsync(string login, CancellationToken cancellationToken = default)
        {
            return await _context.Accounts.AnyAsync(a => a.Login == login, cancellationToken);
        }
    }
}
