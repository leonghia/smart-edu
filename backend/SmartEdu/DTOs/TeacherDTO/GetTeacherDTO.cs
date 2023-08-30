using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.TeacherDTO
{
    public class GetTeacherDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? MainClassId { get; set; }
        public int SubjectId { get; set; }
    }
}
