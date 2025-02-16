using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment_Counseling.Entities
{

    public enum Payment
	{
		NotPaid=1,
		PartiallyPaid = 2,
        Paid = 3
	}
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        // קישור לחבילה
        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        // סטטוס תשלום
        public Payment IsPaid { get; set; }

        // האם השלים את השאלונים
        public bool IsAnswered { get; set; }

        // קישור לתשובות המשתמש
        public List<UserAnswer> UserAnswers { get; set; } = new();
    }

}
