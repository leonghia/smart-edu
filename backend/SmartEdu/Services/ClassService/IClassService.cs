using SmartEdu.DTOs.AcademicProgressDTO;
using SmartEdu.DTOs.AcademicTrackerDTO;
using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.DTOs.TimetableDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.ClassService;

public interface IClassService {
    Task<ServerResponse<object>> UnBookmark(DeleteExtraClassEcBookmarkDTO deleteExtraClassEcBookmarkDTO);
    Task<ServerResponse<object>> UnRegister(DeleteExtraClassStudentDTO deleteExtraClassStudentDTO); 
    Task<ServerResponse<MarkRanking>> GetRanking(int id, MarkFilterOption markFilterOption);
    Task<ServerResponse<IEnumerable<GetTimetableDTO>>> GetTimetableByWeek(TimetableRequestParams timetableRequestParams);
    Task<ServerResponse<IEnumerable<GetAcademicProgressDTO>>> GetAcademicProgressesByDate(AcademicProgressRequestParams academicProgressRequestParams);
    Task<ServerResponse<IEnumerable<GetAcademicTrackerDTO>>> GetAcademicTrackersByStudent(AcademicTrackerRequestParams academicTrackerRequestParams);
}