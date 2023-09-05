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
        [StringLength(30, ErrorMessage = "Your username is limited to 3 to 30 characters.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(64, ErrorMessage = "Your password is limited to 6 to 64 characters.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "Your phone number is limited to 14 digits.")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public ICollection<string> Roles { get; set; }

        [Required]
        [Range(0, 3, ErrorMessage = "Type must be 0 (Admin), 1 (Student), 2 (Parent) or 3 (Teacher).")]
        public byte Type { get; set; }

        public int SubjectId { get; set; } = 0;

        public int ParentId { get; set; } = 0;

        public int MainClassId { get; set; } = 0;
        public string Identifier { get; set; }
    }
}
