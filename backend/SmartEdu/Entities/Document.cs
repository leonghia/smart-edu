using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public double Rating { get; set; } = 0;
        public int NumbersOfRating { get; set; } = 0;
    }
}
