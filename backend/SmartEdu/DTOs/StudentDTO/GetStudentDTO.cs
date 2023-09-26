using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassDTO;
using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.DTOs.MarkDTO;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.StudentDTO
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public GetUserDTO User { get; set; }
        public GetParentDTO Parent { get; set; }
        public GetMainClassDTO MainClass { get; set; }
        public ICollection<GetExtraClassDTO> ExtraClasses { get; set; }
        public GetEcBookmarkDTO EcBookmark { get; set; }
        public ICollection<GetMarkDTO> Marks { get; set; }
    }
}
