using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartEdu.Models;

namespace SmartEdu.Services.BunnyService
{
    public interface IBunnyService
    {
        Task<ServerResponse<IEnumerable<string>>> UploadFiles(MultipleFilesModel model, string path, string fileName, ModelStateDictionary modelState);
        Task<ServerResponse<IEnumerable<string>>> UploadMultipleFiles(MultipleFilesModel model, string path, ModelStateDictionary modelState);
    }
}
