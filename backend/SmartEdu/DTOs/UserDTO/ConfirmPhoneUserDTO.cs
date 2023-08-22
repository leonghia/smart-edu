using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class ConfirmPhoneUserDTO
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
