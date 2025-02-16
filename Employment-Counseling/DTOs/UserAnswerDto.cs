namespace Employment_Counseling.DTOs
{
    public class UserAnswerDto
    {
        public Guid QuestionnaireId { get; set; }
        public string AnswersJson { get; set; } // תשובות בפורמט JSON
    }
}
