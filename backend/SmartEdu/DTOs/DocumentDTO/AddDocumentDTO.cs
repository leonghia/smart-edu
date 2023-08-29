﻿using SmartEdu.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.DTOs.DocumentDTO
{
    public class AddDocumentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int TeacherId { get; set; }
    }
}
