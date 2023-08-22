using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class RegisterUserDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Your username is limited to 3 to 30 characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(64, ErrorMessage = "Your password is limited to 6 to 64 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public ICollection<string> Roles { get; set; }      
    }
}
