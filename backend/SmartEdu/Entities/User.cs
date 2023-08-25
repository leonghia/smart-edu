﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartEdu.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfileImage { get; set; } = "https://nghia.b-cdn.net/images/Product_nest/default-profile-image.webp";
        public string? Address { get; set; }      
    }
}