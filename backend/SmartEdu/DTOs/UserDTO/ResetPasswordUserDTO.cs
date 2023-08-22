using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class ResetPasswordUserDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and the confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
