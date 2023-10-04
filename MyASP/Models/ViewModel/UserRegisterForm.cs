using System.ComponentModel.DataAnnotations;

namespace MyASP.Models.ViewModel
{
    public class UserRegisterForm
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username must contains at least 3 characters")]
        public required string Username { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public required string ConfirmPassword { get; set; }
    }
}
