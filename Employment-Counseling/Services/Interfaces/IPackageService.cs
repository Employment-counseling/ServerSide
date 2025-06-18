using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetAllPackagesAsync();
        Task<PackageDto> GetPackageByIdAsync(Guid packageId);

    }
}
