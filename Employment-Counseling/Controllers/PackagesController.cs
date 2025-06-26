using Employment_Counseling.DTOs;
using Employment_Counseling.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Counseling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PackageDto>>>> GetPackages()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return packages == null || !packages.Any()
                ? NotFound(ApiResponse<IEnumerable<PackageDto>>.Fail("Packages not found"))
                :Ok(ApiResponse<IEnumerable<PackageDto>>.Ok(packages));
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PackageDto>>> GetPackageById(Guid id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            return package == null
                ?NotFound(ApiResponse<PackageDto>.Fail("Package not found"))
                :Ok(ApiResponse<PackageDto>.Ok(package));
        }
    }
}

