using System.ComponentModel.DataAnnotations;

namespace MyASP.Models.ViewModel
{
    public class UserLoginForm
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
