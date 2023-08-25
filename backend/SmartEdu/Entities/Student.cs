using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public Parent Parent { get; set; } // moi hoc sinh chi thuoc ve 1 phu huynh
        [ForeignKey("MainClass")]

        public MainClass MainClassId { get; set; }
        public MainClass MainClass { get; set; }

        public ICollection<ExtraClass> ExtraClasses { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
