using SmartEdu.DTOs.StudentDTO;
using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.ExtraClassDTO
{
    public class GetExtraClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetSubjectDTO Subject { get; set; }
        public GetTeacherDTO Teacher { get; set; }
        public string? Description { get; set; }

        public byte Weekday { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public DateTime OpeningDate { get; set; }
        public string Image { get; set; }
        public byte Capacity { get; set; }
        public ICollection<GetStudentDTO> Students { get; set; }
    }
}
