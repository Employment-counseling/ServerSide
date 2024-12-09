using System.Collections;

namespace EmploymentCounseling.Entities
{
	public enum PackageName
	{
		basic = 1,
		medium = 2,
		full = 3,
		primium = 4
	}
	public class QuestionItem
	{
        public string Question { get; set; }
        public dynamic Answer { get; set; }
    }

    public class Questionnaire
    {
        public string Name { get; set; }
		List<PackageName> Packages { get; set; }
		List<QuestionItem> Questions { get; set; }

	}

	public class Package
	{
        public Guid Id { get; set; }
        public PackageName Name { get; set; }
        public int Price { get; set; }
        public List<Questionnaire> Questionnaires { get; set; }
    }




}
