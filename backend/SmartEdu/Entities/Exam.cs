using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public double Score { get; set; }

        public byte Type { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
