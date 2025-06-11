namespace Employment_Counseling.Entities
{
    public class Counselor: User
    {
        public string Discription {  get; set; }
        public List<Package> Packages { get; set; }
    }
}
