using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public byte Semester { get; set; } = 1;
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public int? Oral_1 { get; set; }
        public int? Oral_2 { get; set; }
        public int? Test15_1 { get; set; }
        public int? Test15_2 { get; set; }
        public int? Test15_3 { get; set; }
        public double? Test45_1 { get; set; }
        public double? Test45_2 { get; set; }
        public double? Test60 { get; set; }
    }
}