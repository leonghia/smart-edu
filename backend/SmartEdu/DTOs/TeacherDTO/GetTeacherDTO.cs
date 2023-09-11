using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.TeacherDTO
{
    public class GetTeacherDTO
    {
        public int Id { get; set; }
        public GetUserDTO User { get; set; }
        public GetMainClassDTO? MainClass { get; set; }
        public GetSubjectDTO Subject { get; set; }
    }
}
