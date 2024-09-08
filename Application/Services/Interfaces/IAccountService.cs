using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDTO> RegisterAccountAsync(AccountDTO accountDto, CancellationToken cancellationToken = default);
    }
}