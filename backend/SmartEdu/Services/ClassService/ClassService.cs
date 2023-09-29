using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Services.ClassService;

public class ClassService : IClassService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClassService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
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