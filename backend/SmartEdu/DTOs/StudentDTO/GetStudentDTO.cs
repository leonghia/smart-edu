using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.StudentDTO
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public GetUserDTO User { get; set; }
        public GetParentDTO Parent { get; set; }
        public GetMainClassDTO MainClass { get; set; }
    }
}
