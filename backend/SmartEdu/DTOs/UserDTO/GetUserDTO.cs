using SmartEdu.Models;
using System.Collections;

namespace SmartEdu.DTOs.UserDTO
{
    public class GetUserDTO
    {
        public string Id { get; set; }       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public string? Address { get; set; }
        public ICollection<string> Roles { get; set; }
		public byte Type { get; set; }
    }
}
