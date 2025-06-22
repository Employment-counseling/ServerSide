using System.ComponentModel.DataAnnotations;

namespace Employment_Counseling.DTOs
{
    public class RegisterCostumerDto
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
        public Guid PackageId { get; set; }
        public string PayPalPaymentId { get; set; }
    }
}