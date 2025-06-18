using Employment_Counseling.DTOs;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<IEnumerable<QuestionnaireDto>> GetQuestionnairesByPackageIdAsync(Guid packageId);
    }
}