using Employment_Counseling.Data;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly ApplicationDbContext _context;

        public CostumerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> AddCostumer(Costumer costumer)
        {
            _context.Costumers.Add(costumer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
