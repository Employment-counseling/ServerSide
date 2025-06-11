
namespace Employment_Counseling.Entities
{
    public class AnswerItem
    {
        public Guid Id { get; set; }

        public Guid UserAnswersId { get; set; }
        public UserAnswers UserAnswers { get; set; }

        public Guid QuestionId { get; set; }
        public QuestionItem Question { get; set; }

        public string Value { get; set; }
    }
}
