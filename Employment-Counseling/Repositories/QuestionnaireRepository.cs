using Employment_Counseling.Data;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employment_Counseling.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionnaireRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Questionnaire>> GetQuestionnairesByPackageIdAsync(Guid packageId)
        {
            return await _context.Questionnaires
                .Where(q => q.Packages.Any(p => p.Id == packageId))
                .Include(q => q.Questions).ToListAsync();
                
        }       
    }
}
