using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.ParentDTO
{
    public class GetParentDTO
    {
        public int Id { get; set; }
        public GetUserDTO User { get; set; }

    }
}
