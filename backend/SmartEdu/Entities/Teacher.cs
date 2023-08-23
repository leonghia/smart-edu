using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
