using System.ComponentModel.DataAnnotations;

namespace Employment_Counseling.DTOs
{
    public class ChangePasswordDto
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string NewPassword { get; set; }
    }
}