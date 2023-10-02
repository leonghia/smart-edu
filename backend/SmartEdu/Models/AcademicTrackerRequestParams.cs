namespace SmartEdu.Models
{
    public class AcademicTrackerRequestParams
    {
        public int StudentId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}