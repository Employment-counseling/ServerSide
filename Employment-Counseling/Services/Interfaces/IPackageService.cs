using Employment_Counseling.Entities;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IPackageService
    {
        Task<IEnumerable<Package>> GetAllPackagesAsync();

    }
}
