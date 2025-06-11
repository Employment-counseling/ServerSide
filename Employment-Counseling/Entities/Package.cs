namespace Employment_Counseling.Entities
{

    public class Package
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IncludeCall { get; set; }
        public bool IncludeTilDiagnosis { get; set; }


        public List<Questionnaire>? Questionnaires { get; set; }
        public List<Counselor>? Counselors { get; set; }
    }

}
