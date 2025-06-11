using Employment_Counseling.Entities.Enums;

namespace Employment_Counseling.Entities
{
    public class Costumer: User
    {
        public PaymentStatus IsPaid { get; set; }
        public bool IsComplitedQuestionnaires { get; set; }
        public bool IsAnswered { get; set; }


        public Guid PackageId { get; set; }
        public Package Package { get; set; }        

        public List<UserAnswers> UserAnswers { get; set; }
    }
}
