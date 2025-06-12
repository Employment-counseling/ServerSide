namespace Employment_Counseling.DTOs
{
    public class CounselorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Discription { get; set; }
        public List<Guid> PackageIds { get; set; }
    }


}
