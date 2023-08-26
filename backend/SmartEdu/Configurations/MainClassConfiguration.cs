using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartEdu.Entities;

namespace SmartEdu.Configurations
{
    public class MainClassConfiguration : IEntityTypeConfiguration<MainClass>
    {
        public void Configure(EntityTypeBuilder<MainClass> builder)
        {
            builder.HasData(
                new MainClass
                {
                    Id = 1,
                    Name = "10A",

                },
                new MainClass
                {
                    Id = 2,
                    Name = "10B"
                },
                new MainClass
                {
                    Id = 3,
                    Name = "10C"
                },
                new MainClass
                {
                    Id = 4,
                    Name = "10D"
                },
                new MainClass
                {
                    Id = 5,
                    Name = "10E"
                },
                new MainClass
                {
                    Id = 6,
                    Name = "10G"
                },
                new MainClass
                {
                    Id = 7,
                    Name = "10H"
                },
                new MainClass
                {
                    Id = 8,
                    Name = "10I"
                },
                new MainClass
                {
                    Id = 9,
                    Name = "10K"
                },
                new MainClass
                {
                    Id = 10,
                    Name = "10M"
                }
                );
        }
    }
}
