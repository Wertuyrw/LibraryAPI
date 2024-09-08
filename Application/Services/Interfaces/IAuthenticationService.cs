using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string?> GetAccountTokenAsync(AccountDTO accountDto, CancellationToken cancellationToken = default);
    }
}
