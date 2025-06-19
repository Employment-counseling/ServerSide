using System.ComponentModel.DataAnnotations;

namespace Employment_Counseling.DTOs
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }

        [Phone(ErrorMessage = "Phone format is invalid")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string? EmailAddress { get; set; }
    }
}
