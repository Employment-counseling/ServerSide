namespace Employment_Counseling.Entities
{
    public class UserAnswers
    {
        public Guid Id { get; set; }

        public Guid CostumerId { get; set; }
        public Costumer Costumer { get; set; }

        public Guid QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public DateTime DateSubmitted { get; set; }

        public List<AnswerItem> Answers { get; set; }

    }
}
