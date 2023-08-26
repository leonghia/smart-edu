﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class ExtraClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        //[ForeignKey("Teacher")]
        //public int TeacherId { get; set; } //TeacherId la khoa ngoai cua bang teacher
        //public Teacher Teacher { get; set; }
    }
}
