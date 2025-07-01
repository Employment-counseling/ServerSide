using Employment_Counseling.Data;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AuthToken> GetTokenAsync(string token)
        {
            return await _context.UsersTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task CreateTokenAsync(AuthToken token)
        {
            await _context.UsersTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task MarkTokenAsUsedAsync(string token)
        {
            var t = await _context.UsersTokens.FirstOrDefaultAsync(x => x.Token == token);
            if (t != null)
            {
                t.IsUsed = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTokenAsync(string token)
        {
            var t = await _context.UsersTokens.FirstOrDefaultAsync(x => x.Token == token);
            if (t != null)
            {
                _context.UsersTokens.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AuthToken> GetByTokenAsync(string token)
        {
            return await _context.UsersTokens.FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task ReplaceRefreshToken(AuthToken oldToken, AuthToken newToken)
        {
            _context.UsersTokens.Remove(oldToken);
            await _context.UsersTokens.AddAsync(newToken);
            await _context.SaveChangesAsync();
        }
    }

}
