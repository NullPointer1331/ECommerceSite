using System.ComponentModel.DataAnnotations;
namespace ECommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        public string? Username { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
