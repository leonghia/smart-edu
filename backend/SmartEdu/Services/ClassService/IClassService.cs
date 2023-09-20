using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.ClassService;

public interface IClassService {
    Task<ServerResponse<object>> UnBookmark(DeleteExtraClassEcBookmarkDTO deleteExtraClassEcBookmarkDTO);
    Task<ServerResponse<object>> UnRegister(DeleteExtraClassStudentDTO deleteExtraClassStudentDTO); 
}