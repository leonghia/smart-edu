using System.ComponentModel.DataAnnotations.Schema;
using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.Entities;

namespace SmartEdu.DTOs.TimetableDTO;

public class GetTimetableDTO
{
    public int Id { get; set; }
    public GetMainClassDTO MainClass { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public GetTeacherDTO Teacher { get; set; }
    public string Topic { get; set; }
}