using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.StudentDTO
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ParentId { get; set; }
        public int MainClassId { get; set; }
    }
}
