using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public double Score { get; set; }

        public byte Type { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
