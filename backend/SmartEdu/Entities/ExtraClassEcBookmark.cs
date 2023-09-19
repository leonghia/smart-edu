using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities;

public class ExtraClassEcBookmark
{
    [ForeignKey("EcBookmark")]
    public int EcBookmarkId { get; set; }
    public EcBookmark EcBookmark { get; set; }
    [ForeignKey("ExtraClass")]
    public int ExtraClassId { get; set; }
    public ExtraClass ExtraClass { get; set; }
}