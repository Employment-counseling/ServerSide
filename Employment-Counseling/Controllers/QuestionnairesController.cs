using Employment_Counseling.DTOs;
using Employment_Counseling.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Counseling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionnairesController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnairesController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }
       

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<QuestionnaireDto>>>> GetQuestionnairesByPackageId(Guid id)
        {
            var questionnaires = await _questionnaireService.GetQuestionnairesByPackageIdAsync(id);
            return questionnaires == null
                ?NotFound(ApiResponse<IEnumerable<QuestionnaireDto>>.Fail("Questionnaires not found"))
                :Ok(ApiResponse<IEnumerable<QuestionnaireDto>>.Ok(questionnaires));
        }
    }
}

