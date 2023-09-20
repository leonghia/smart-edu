using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities;

public class EcBookmark
{
    public int Id { get; set; }
    public ICollection<ExtraClass> ExtraClasses { get; set; }
}