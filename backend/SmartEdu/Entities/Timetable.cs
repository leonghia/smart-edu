using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities;

public class Timetable
{
    public int Id { get; set; }
    [ForeignKey("MainClass")]
    public int MainClassId { get; set; }
    public MainClass MainClass { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public string Topic { get; set; }
}