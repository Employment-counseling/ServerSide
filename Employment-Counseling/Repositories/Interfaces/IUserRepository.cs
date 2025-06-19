using Employment_Counseling.Entities;

namespace Employment_Counseling.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmailAddress(string email);
    }
}