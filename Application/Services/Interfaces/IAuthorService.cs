using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorTakenDTO>> GetAuthorsAsync();
        Task<AuthorCreateDTO> AddAuthorAsync(AuthorCreateDTO authorCreateDto,
            CancellationToken cancellationToken = default);
        Task<AuthorCreateDTO?> UpdateAuthorAsync(int id, AuthorCreateDTO authorCreateDto,
            CancellationToken cancellationToken = default);
        Task<AuthorTakenDTO?> DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
