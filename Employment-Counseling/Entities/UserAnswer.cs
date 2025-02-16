namespace Employment_Counseling.Entities
{
    public class UserAnswer
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public string AnswersJson { get; set; } // תשובות המשתמש בפורמט JSON
    }
}
