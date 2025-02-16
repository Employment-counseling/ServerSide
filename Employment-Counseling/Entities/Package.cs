namespace Employment_Counseling.Entities
{
    public enum PackageName
    {
        basic = 1,
        medium = 2,
        full = 3,
        primium = 4
    }
    public class Package
    {
        public Guid Id { get; set; }
        public PackageName Name { get; set; }
        public int Price { get; set; }

        // קשרים
        public List<PackageQuestionnaire> PackageQuestionnaires { get; set; } = new();
        public List<User> Users { get; set; } = new(); // משתמשים שרכשו את החבילה
    }

}
