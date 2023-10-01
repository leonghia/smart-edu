using SmartEdu.DTOs.StudentDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.DTOs.TimetableDTO;

namespace SmartEdu.DTOs.MainClassDTO
{
    public class GetMainClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetTeacherDTO Teacher { get; set; }
        public ICollection<GetStudentDTO> Students { get; set; }
        public ICollection<GetTimetableDTO> Timetables { get; set; }
    }
}
