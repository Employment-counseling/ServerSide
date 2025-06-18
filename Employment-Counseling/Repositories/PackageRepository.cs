using Employment_Counseling.Data;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages.ToListAsync();
        }


        public async Task<Package> GetPackageByIdAsync(Guid packageId)
        {
            return await _context.Packages.FirstOrDefaultAsync(p => p.Id == packageId);
        }
    }
}
