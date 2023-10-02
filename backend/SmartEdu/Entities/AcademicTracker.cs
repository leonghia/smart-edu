using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class AcademicTracker
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Attendance { get; set; }
        public string Homework { get; set; }
        public string? Marks { get; set; }
        public string? TeacherComment { get; set; }
    }
}