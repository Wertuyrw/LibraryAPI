using System.Security.Claims;

namespace Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateTokenAsync(List<Claim> claims);
    }
}
