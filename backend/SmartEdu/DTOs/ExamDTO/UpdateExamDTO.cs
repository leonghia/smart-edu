namespace SmartEdu.DTOs.ExamDTO
{
    public class UpdateExamDTO
    {
        public double Score { get; set; }

        public byte Type { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
