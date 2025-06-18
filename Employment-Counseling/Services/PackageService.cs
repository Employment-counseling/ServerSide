using AutoMapper;
using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using System.Collections.Generic;

namespace Employment_Counseling.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;

        public PackageService(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PackageDto>> GetAllPackagesAsync()
        {
            var packages = await _packageRepository.GetAllPackagesAsync();
            return _mapper.Map<IEnumerable<PackageDto>>(packages);
        }
        public async Task<PackageDto> GetPackageByIdAsync(Guid packageId)
        {
            var package = await _packageRepository.GetPackageByIdAsync(packageId);
            return _mapper.Map<PackageDto>(package);
        }
    }
}
