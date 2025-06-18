using AutoMapper;
using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using System.Collections.Generic;

namespace Employment_Counseling.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        private readonly IMapper _mapper;

        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository, IMapper mapper)
        {
            _questionnaireRepository = questionnaireRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionnaireDto>> GetQuestionnairesByPackageIdAsync(Guid packageId)
        {
            var questionnaires = await _questionnaireRepository.GetQuestionnairesByPackageIdAsync(packageId);
            return _mapper.Map<IEnumerable<QuestionnaireDto>>(questionnaires);
        }       
    }
}
