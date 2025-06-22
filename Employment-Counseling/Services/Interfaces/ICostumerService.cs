using Employment_Counseling.DTOs;

namespace Employment_Counseling.Services.Interfaces
{
    public interface ICostumerService
    {
        Task<LoginResult> RegisterCostumerAsync(RegisterCostumerDto dto);
    }
}