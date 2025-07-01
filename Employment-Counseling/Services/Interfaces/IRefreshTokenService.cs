using Employment_Counseling.Entities;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateRefreshToken(Guid userId);
        Task<Guid?> ValidateRefreshToken(string token);
        Task RevokeRefreshToken(string token);
        Task<AuthToken> GetByTokenAsync(string token);
        Task ReplaceRefreshToken(AuthToken oldToken, AuthToken newToken);
    }

}