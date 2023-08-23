using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Student> Students { get; set; } // 1 phu huynh co the co nhieu con (hoc sinh)
    }
}
