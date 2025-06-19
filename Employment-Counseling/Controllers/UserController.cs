using Employment_Counseling.DTOs;
using Employment_Counseling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Counseling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return users == null || !users.Any()
                ? NotFound(ApiResponse<IEnumerable<UserDto>>.Fail("Users not found"))
                :Ok(ApiResponse<IEnumerable<UserDto>>.Ok(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            return user == null
                ?NotFound(ApiResponse<UserDto>.Fail("User not found"))
                :Ok(ApiResponse<UserDto>.Ok(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResult>>> Login([FromBody] LoginDto login)
        {
            var loginResult = await _userService.Login(login.Email, login.Password);
            return loginResult.Success
                ? Ok(ApiResponse<LoginResult>.Ok(loginResult))
                : NotFound(ApiResponse<LoginResult>.Fail(loginResult.ErrorMessage?? "Login Faild"));
           
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserDetails(Guid id, [FromBody] UpdateUserDto userDetails)
        {
            var update = _userService.UpdateUserDetails(id, userDetails).Result;
            return update
                ? Ok(ApiResponse<string>.Ok("","User updated successfully"))
                : NotFound(ApiResponse<string>.Fail("User not found"));
        }
    }
}

