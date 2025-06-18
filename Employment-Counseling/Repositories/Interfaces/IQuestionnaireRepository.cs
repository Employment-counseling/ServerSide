using Employment_Counseling.Entities;

namespace Employment_Counseling.Repositories.Interfaces
{
    public interface IQuestionnaireRepository
    {
        Task<IEnumerable<Questionnaire>> GetQuestionnairesByPackageIdAsync(Guid packageId);
    }
}