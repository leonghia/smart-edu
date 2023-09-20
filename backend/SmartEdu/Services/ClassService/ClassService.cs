using SmartEdu.DTOs.EcBookmarkDTO;
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
}