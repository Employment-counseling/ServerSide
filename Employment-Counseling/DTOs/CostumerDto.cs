using Employment_Counseling.Entities.Enums;

namespace Employment_Counseling.DTOs
{
    public class CostumerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public PaymentStatus IsPaid { get; set; }
        public bool IsComplitedQuestionnaires { get; set; }
        public bool IsAnswered { get; set; }
        public Guid PackageId { get; set; }
        public List<Guid> UserAnswersIds { get; set; }
    }


}
