using Employment_Counseling.DTOs;
using Employment_Counseling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Counseling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;
        }
             

        [HttpPost("Register")]
        public async Task<ActionResult<ApiResponse<CostumerDto>>> Register([FromBody] RegisterCostumerDto register)
        {
            var loginResult = await _costumerService.RegisterCostumerAsync(register);
            return loginResult.Success
                ? Ok(ApiResponse<LoginResult>.Ok(loginResult))
                : NotFound(ApiResponse<LoginResult>.Fail(loginResult.ErrorMessage ?? "Register Faild"));

        }

    }
}

