using Employment_Counseling.Entities;

namespace Employment_Counseling.DTOs
{
    public class QuestionItemDto
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
    }

    public class QuestionnaireDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<QuestionItemDto> Questions { get; set; } 
    }
}
