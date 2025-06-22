using Employment_Counseling.Entities;

namespace Employment_Counseling.Repositories.Interfaces
{
    public interface ICostumerRepository
    {
        Task<bool> AddCostumer(Costumer costumer);
    }
}