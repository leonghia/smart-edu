using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class LoginUserDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "Your username is limited to 3 to 30 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to 6 to 15 characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
