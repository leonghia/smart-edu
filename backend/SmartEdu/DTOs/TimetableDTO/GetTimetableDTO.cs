using System.ComponentModel.DataAnnotations.Schema;
using SmartEdu.Entities;

namespace SmartEdu.DTOs.TimetableDTO;

public class GetTimetableDTO
{
    public int Id { get; set; }
    public MainClass MainClass { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public Teacher Teacher { get; set; }
    public string Topic { get; set; }
}