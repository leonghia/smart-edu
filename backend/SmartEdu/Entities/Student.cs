using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [StringLength(20)]
        public string Identifier { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public Parent Parent { get; set; } // moi hoc sinh chi thuoc ve 1 phu huynh
        [ForeignKey("MainClass")]
        public int MainClassId { get; set; }
        public MainClass MainClass { get; set; }

        public ICollection<ExtraClass> ExtraClasses { get; set; }

        [ForeignKey("EcBookmark")]
        public int EcBookmarkId { get; set; }
        public EcBookmark EcBookmark { get; set; }
        
        public ICollection<Mark> Marks { get; set; }
    }
}
