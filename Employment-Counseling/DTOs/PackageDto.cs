namespace Employment_Counseling.DTOs
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IncludeCall { get; set; }
        public bool IncludeTilDiagnosis { get; set; }

        public List<Guid> QuestionnaireIds { get; set; }
        public List<Guid> CounselorIds { get; set; }
    }

}
