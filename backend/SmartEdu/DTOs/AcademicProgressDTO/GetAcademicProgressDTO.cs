using SmartEdu.DTOs.MarkDTO;
using SmartEdu.DTOs.TimetableDTO;

namespace SmartEdu.DTOs.AcademicProgressDTO
{
    public class GetAcademicProgressDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public GetTimetableDTO Timetable { get; set; }
        public int Attendance { get; set; } // -2: late, -1: absent (no leave), 0: absent (with leave), 1: good
        public bool IsDoneHomework { get; set; } // false: not done, true: done
        public ICollection<GetMarkDTO> Marks { get; set; }
        public string TeacherComment { get; set; }
    }
}