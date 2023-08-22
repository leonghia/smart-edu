using System.ComponentModel.DataAnnotations;

namespace SmartEdu.DTOs.UserDTO
{
    public class UpdateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string? Address { get; set; }

        [DataType(DataType.Url)]
        [StringLength(255)]
        public string ProfileImage { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
