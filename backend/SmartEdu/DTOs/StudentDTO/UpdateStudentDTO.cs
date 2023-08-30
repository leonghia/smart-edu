using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.StudentDTO
{
    public class UpdateStudentDTO
    {
        public int ParentId { get; set; }
        public int MainClassId { get; set; }
    }
}
