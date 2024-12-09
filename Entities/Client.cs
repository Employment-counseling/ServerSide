using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCounseling.Entities
{
  
	enum Payment
	{
		NotPaid=1,
		PartiallyPaid = 2,
        Paid = 3
	}
	internal class Client
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public PackageName Package { get; set; }
        public Payment IsPaid { get; set; }
        public bool IsAnswered {get; set; }

    }
}
