using SmartEdu.DTOs.ExtraClassDTO;

namespace SmartEdu.DTOs.EcBookmarkDTO;

public class GetEcBookmarkDTO {
    public int Id { get; set; }
    public ICollection<GetExtraClassDTO> ExtraClasses { get; set; }
}