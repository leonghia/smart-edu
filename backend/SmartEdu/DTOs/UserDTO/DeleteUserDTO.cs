using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class DeleteUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
