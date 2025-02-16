namespace Employment_Counseling.Entities
{
    public class PackageQuestionnaire
    {
        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public Guid QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
