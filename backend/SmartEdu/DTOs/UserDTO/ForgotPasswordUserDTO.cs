using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class ForgotPasswordUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
