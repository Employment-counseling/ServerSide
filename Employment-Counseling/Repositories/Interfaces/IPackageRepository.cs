using Employment_Counseling.Entities;

namespace Employment_Counseling.Repositories.Interfaces
{
    public interface IPackageRepository
    {
        Task<IEnumerable<Package>> GetAllPackagesAsync();
    }
}
