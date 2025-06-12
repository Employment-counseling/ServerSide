namespace Employment_Counseling.DTOs
{
    public class UserAnswersDto
    {
        public Guid Id { get; set; }
        public Guid CostumerId { get; set; }
        public Guid QuestionnaireId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<AnswerItemDto> Answers { get; set; }
    }

}
