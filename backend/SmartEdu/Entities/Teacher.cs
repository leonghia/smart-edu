﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("MainClass")]
        public int MainClassId { get; set; }
        public MainClass MainClass { get; set; }
        public ICollection<ExtraClass> ExtraClasses { get; set; }
        public ICollection<Document> Documents { get; set; }

    }
}
