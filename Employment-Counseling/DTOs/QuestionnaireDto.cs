using Employment_Counseling.Entities;

namespace Employment_Counseling.DTOs
{
    public class QuestionnaireDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<QuestionItemDto> Questions { get; set; }
        public List<Guid> PackagesIds { get; set; }

    }
}
