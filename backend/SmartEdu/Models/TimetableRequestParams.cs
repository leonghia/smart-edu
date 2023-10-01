using SmartEdu.Entities;

namespace SmartEdu.Models;

public class TimetableRequestParams
{
    public int MainClassId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}