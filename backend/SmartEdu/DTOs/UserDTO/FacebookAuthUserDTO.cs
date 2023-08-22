using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class FacebookAuthUserDTO
    {
        [Required]
        public string? Credential { get; set; }
        public string? Provider { get; set; }
        public List<string>? Roles { get; set; }
        public string? UserId { get; set; }
    }
}
