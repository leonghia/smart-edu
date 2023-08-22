using System.ComponentModel.DataAnnotations;

namespace SmartEdu.Models
{
    public class MultipleFilesModel
    {
        [Required(ErrorMessage = "Please select files")]
        public List<IFormFile> Files { get; set; }     
    }
}
