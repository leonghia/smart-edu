﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartEdu.Entities;

namespace SmartEdu.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Maths",
                },
                new Subject
                {
                    Id = 2,
                    Name = "Literature",
                },
                new Subject
                {
                    Id = 3,
                    Name = "English",
                },
                new Subject
                {
                    Id = 4,
                    Name = "Physics"
                },
                new Subject
                {
                    Id = 5,
                    Name = "Chemistry"
                },
                new Subject
                {
                    Id = 6,
                    Name = "Biology"
                },
                new Subject
                {
                    Id = 7,
                    Name = "History"
                },
                new Subject
                {
                    Id = 8,
                    Name = "Geography"
                }
                );
        }
    }
}
