using Employment_Counseling.Entities;

namespace Employment_Counseling.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<AuthToken> GetTokenAsync(string token);
        Task CreateTokenAsync(AuthToken token);
        Task MarkTokenAsUsedAsync(string token);
        Task DeleteTokenAsync(string token);
        Task<AuthToken> GetByTokenAsync(string token);
        Task ReplaceRefreshToken(AuthToken oldToken, AuthToken newToken);
    }

}