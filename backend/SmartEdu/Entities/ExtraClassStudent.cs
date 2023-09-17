using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities;

public class ExtraClassStudent
{
    public int ExtraClassId { get; set; }
    public ExtraClass ExtraClass { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime RegisteredOn { get; set; } = DateTime.UtcNow;
}