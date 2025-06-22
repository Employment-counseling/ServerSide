using Employment_Counseling.DTOs;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(Guid userId);
        Task<LoginResult> Login(string email, string password);
        Task<bool> UpdateUserDetails(Guid id, UpdateUserDto dto);
        Task<(bool Success, string ErrorMessage)> ChangePassword(ChangePasswordDto dto);
    }
}