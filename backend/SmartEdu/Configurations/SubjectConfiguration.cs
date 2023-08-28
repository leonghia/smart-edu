using Microsoft.EntityFrameworkCore;
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
                }
                );
        }
    }
}
