using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartEdu.Entities;

namespace SmartEdu.Configurations
{
    public class ExtraClassConfiguration : IEntityTypeConfiguration<ExtraClass>
    {
        public void Configure(EntityTypeBuilder<ExtraClass> builder)
        {
            builder.HasData(
                new ExtraClass
                {
                    Id = 1,
                    Name = "Maths M2308-10"
                },
                new ExtraClass
                {
                    Id = 2,
                    Name = "Literature A2308-10"
                },
                new ExtraClass
                {
                    Id = 3,
                    Name = "English M2308-10"
                }
                );
        }
    }
}


