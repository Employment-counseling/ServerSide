namespace Employment_Counseling.DTOs
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // שם החבילה
        public int Price { get; set; } // מחיר החבילה
        public List<string> Questionnaires { get; set; } // שמות השאלונים של החבילה
    }
}
