using Employment_Counseling.Entities;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}