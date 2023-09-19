using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class ExtraClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; } //TeacherId la khoa ngoai cua bang teacher
        public Teacher Teacher { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string? Description { get; set; }
        public byte Weekday { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public DateTime OpeningDate { get; set; }
        public string Image { get; set; } = "https://nghia.b-cdn.net/smart-edu/images/extra-classes/extra-class-default-image.webp";
        public byte Capacity { get; set; }
        public ICollection<EcBookmark> EcBookmarks { get; set; }
    }
}
