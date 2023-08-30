using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.ExamDTO
{
    public class GetExamDTO
    {
        public int Id { get; set; }

        public double Score { get; set; }

        public byte Type { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
