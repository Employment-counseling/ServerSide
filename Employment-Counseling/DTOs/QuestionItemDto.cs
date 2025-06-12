using Employment_Counseling.Entities.Enums;

namespace Employment_Counseling.DTOs
{
    public class QuestionItemDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string>? Options { get; set; }
        public Guid QuestionnaireId { get; set; }
    }

}
