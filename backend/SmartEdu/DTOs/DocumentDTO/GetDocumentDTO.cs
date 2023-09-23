﻿using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.DocumentDTO
{
    public class GetDocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public Teacher Teacher { get; set; }
        public double Rating { get; set; } = 0;
        public int NumbersOfRaing { get; set; } = 0;
    }
}
