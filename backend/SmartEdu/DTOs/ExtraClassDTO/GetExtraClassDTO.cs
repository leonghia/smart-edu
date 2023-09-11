using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.ExtraClassDTO
{
    public class GetExtraClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetSubjectDTO Subject { get; set; }
    }
}
