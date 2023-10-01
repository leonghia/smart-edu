using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class AcademicProgress
    {
        public int Id { get; set; }
        [ForeignKey("Timetable")]
        public int TimetableId { get; set; }
        public Timetable Timetable { get; set; }
        [ForeignKey("Student")]
        public int StudentId {get;set;}
        public Student Student {get;set;}
        public int Attendance { get; set; } // -2: late, -1: absent (no leave), 0: absent (with leave), 1: good
        public bool IsDoneHomework { get; set; } // false: not done, true: done
        public ICollection<Mark> Marks { get; set; }
        public string TeacherComment { get; set; }

    }
}