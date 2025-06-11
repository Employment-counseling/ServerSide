using System.Collections;

namespace Employment_Counseling.Entities
{   
    public class Questionnaire
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public List<QuestionItem> Questions { get; set; }
        public List<Package> Packages { get; set; }


    }
}
