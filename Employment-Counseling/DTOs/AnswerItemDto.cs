namespace Employment_Counseling.DTOs
{
    public class AnswerItemDto
    {
        public Guid Id { get; set; }
        public Guid UserAnswersId { get; set; }
        public Guid QuestionId { get; set; }
        public string Value { get; set; }
    }

}
