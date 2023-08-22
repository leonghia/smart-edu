using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class VerifyPhoneUserDTO
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
