using Employment_Counseling.Entities;
using Employment_Counseling.Entities.Enums;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Employment_Counseling.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public RefreshTokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<string> GenerateRefreshToken(Guid userId)
        {
            AuthToken refreshToken = new AuthToken()
            {
                Token = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                UserId = userId,
                Type = TokenType.Refresh,
                IsUsed = false
            };
            await _tokenRepository.CreateTokenAsync(refreshToken);
            return refreshToken.Token;
        }

        public async Task<Guid?> ValidateRefreshToken(string token)
        {
            var tokenInDB =  await _tokenRepository.GetTokenAsync(token);
            if(tokenInDB == null || tokenInDB.IsUsed || tokenInDB.ExpiresAt < DateTime.UtcNow)
            {
                return null;
            }
            return tokenInDB.UserId;
        }
        public async Task RevokeRefreshToken(string token)
        {
            await _tokenRepository.MarkTokenAsUsedAsync(token);
        }
        public async Task<AuthToken> GetByTokenAsync(string token)
        {
            return await _tokenRepository.GetByTokenAsync(token);
        }

        public async Task ReplaceRefreshToken(AuthToken oldToken, AuthToken newToken)
        {
            await _tokenRepository.ReplaceRefreshToken(oldToken, newToken);

        }
    }

}
