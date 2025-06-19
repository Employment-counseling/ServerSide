using Employment_Counseling.Data;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
                
        }
        public async Task<User> GetUserById(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByEmailAddress(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress
                                .Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
