using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.ClassService;

public interface IClassService {
    Task<ServerResponse<object>> UnBookmark(DeleteExtraClassEcBookmarkDTO deleteExtraClassEcBookmarkDTO);
}