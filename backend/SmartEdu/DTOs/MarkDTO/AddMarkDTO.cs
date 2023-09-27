namespace SmartEdu.DTOs.MarkDTO
{
    public class AddMarkDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public byte Semester { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public int Oral_1 { get; set; }
        public int Oral_2 { get; set; }
        public int Test15_1 { get; set; }
        public int Test15_2 { get; set; }
        public int Test15_3 { get; set; }
        public double Test45_1 { get; set; }
        public double Test45_2 { get; set; }
        public double Test60 { get; set; }
    }
}