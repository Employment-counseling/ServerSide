namespace Employment_Counseling.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public PackageDto Package { get; set; } // שם החבילה שהמשתמש רכש
        public List<QuestionnaireDto> Questionnaires { get; set; } // השאלונים שהמשתמש מקבל
        public List<UserAnswerDto> Answers { get; set; } // תשובות המשתמש
    }
}
