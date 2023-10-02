using AutoMapper;
using SmartEdu.DTOs.AcademicProgressDTO;
using SmartEdu.DTOs.AcademicTrackerDTO;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.DTOs.TimetableDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Services.ClassService;

public class ClassService : IClassService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ServerResponse<IEnumerable<GetAcademicProgressDTO>>> GetAcademicProgressesByDate(AcademicProgressRequestParams academicProgressRequestParams)
    {
        var response = new ServerResponse<IEnumerable<GetAcademicProgressDTO>>();

        var academicProgresses = await _unitOfWork.AcademicProgressRepository.GetAll(null, aP => aP.StudentId == academicProgressRequestParams.StudentId && aP.Timetable.From.Date == academicProgressRequestParams.Date.Date && aP.Timetable.To.Date == academicProgressRequestParams.Date.Date, null, new List<string>{ "Timetable.Teacher.User", "Marks", "Timetable.Teacher.Subject"});

        if (academicProgresses is null || academicProgresses.Count() == 0) return response;

        var academicProgressesDTO = academicProgresses.Select(aP => _mapper.Map<GetAcademicProgressDTO>(aP));

        response.Data = academicProgressesDTO;

        return response;
    }

    public async Task<ServerResponse<IEnumerable<GetAcademicTrackerDTO>>> GetAcademicTrackersByStudent(AcademicTrackerRequestParams academicTrackerRequestParams)
    {
        var response = new ServerResponse<IEnumerable<GetAcademicTrackerDTO>>();

        var academicTrackers = await _unitOfWork.AcademicTrackerRepository.GetAll(null, aT => aT.StudentId == academicTrackerRequestParams.StudentId && aT.Date.Date >= academicTrackerRequestParams.From.Date && aT.Date.Date < academicTrackerRequestParams.To.Date);

        var academicTrackersDTO = academicTrackers.Select(aT => _mapper.Map<GetAcademicTrackerDTO>(aT));

        response.Data = academicTrackersDTO;
        return response;
    }

    public async Task<ServerResponse<MarkRanking>> GetRanking(int id, MarkFilterOption markFilterOption)
    {
        var serverResponse = new ServerResponse<MarkRanking>();
        var results = new List<double>();
        var student = await _unitOfWork.StudentRepository.GetSingle(s => s.Id == id, new List<string>{ "Marks" });
        var marks = student.Marks.ToList();
        var studentGPA = MarkCalculator.CalculateGPA(marks, markFilterOption);
        results.Add(studentGPA);
        var students = await _unitOfWork.StudentRepository.GetAll(null, s => s.MainClassId == student.MainClassId, null, new List<string>{ "Marks" });
        foreach (var s in students)
        {
            var otherGPA = MarkCalculator.CalculateGPA(s.Marks.ToList(), markFilterOption);
            if (!results.Contains(otherGPA)) results.Add(otherGPA);
        }
        results.Sort();
        var ranking = results.FindIndex(r => r == studentGPA);
        serverResponse.Data = new MarkRanking { Ranking = ranking, NumbersOfStudents = students.Count() };
        return serverResponse;
    }

    public async Task<ServerResponse<IEnumerable<GetTimetableDTO>>> GetTimetableByWeek(TimetableRequestParams timetableRequestParams)
    {
        var response = new ServerResponse<IEnumerable<GetTimetableDTO>>();

        var results = await _unitOfWork.TimetableRepository.GetAll(null, t => t.MainClassId == timetableRequestParams.MainClassId && t.From >= timetableRequestParams.From && t.To <= timetableRequestParams.To, null, new List<string>{ "Teacher.Subject" });

        if (results.Count() == 0)
        {
            response.Succeeded = false;
            response.Message = "No timetables found for that datetime ranges.";
            return response;
        }

        var resultsDTO = results.Select(r => _mapper.Map<GetTimetableDTO>(r));

        response.Data = resultsDTO;

        return response;
    }

    public async Task<ServerResponse<object>> UnBookmark(DeleteExtraClassEcBookmarkDTO deleteExtraClassEcBookmarkDTO)
    {
        var serverResponse = new ServerResponse<object>();
        var entity = await _unitOfWork.ExtraClassEcBookmarkRepository.GetSingle(eceb => eceb.EcBookmarkId == deleteExtraClassEcBookmarkDTO.EcBookmarkId && eceb.ExtraClassId == deleteExtraClassEcBookmarkDTO.ExtraClassId);

        if (entity is null)
        {
            serverResponse.Succeeded = false;
            serverResponse.Message = "Could not find any result with that EcBookmarkId and ExtraClassId.";
            return serverResponse;
        }
        await _unitOfWork.ExtraClassEcBookmarkRepository.Delete(deleteExtraClassEcBookmarkDTO.EcBookmarkId, deleteExtraClassEcBookmarkDTO.ExtraClassId);
        await _unitOfWork.Save();
        return serverResponse;
    }

    public async Task<ServerResponse<object>> UnRegister(DeleteExtraClassStudentDTO deleteExtraClassStudentDTO)
    {
        var serverResponse = new ServerResponse<Object>();

        //Kiem tra xem du lieu co ton tai khong 
        var result = await _unitOfWork.ExtraClassStudentRepository.GetSingle(ecs => ecs.ExtraClassId == deleteExtraClassStudentDTO.ExtraClassId && ecs.StudentId == deleteExtraClassStudentDTO.StudentId);

        if (result is null)
        {
            serverResponse.Succeeded = false;
            serverResponse.Message = "Cannot find the ExtraClassId with that StudentId.";
            return serverResponse;
        }

        await _unitOfWork.ExtraClassStudentRepository.Delete(deleteExtraClassStudentDTO.ExtraClassId, deleteExtraClassStudentDTO.StudentId);
        await _unitOfWork.Save();
        return serverResponse;

    }
}