namespace SmartEdu.DTOs.AcademicTrackerDTO
{
    public class GetAcademicTrackerDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public string Attendance { get; set; }
        public string Homework { get; set; }
        public string Marks { get; set; }
        public string TeacherComment { get; set; }
    }
}