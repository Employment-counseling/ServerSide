using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;

namespace Employment_Counseling.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _packageRepository.GetAllPackagesAsync();
        }
    }
}
