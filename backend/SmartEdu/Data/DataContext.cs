using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartEdu.Configurations;
using SmartEdu.Entities;

namespace SmartEdu.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //modelBuilder.Entity<Blog>().HasMany(x => x.BlogPosts).WithOne(x => x.Blog).HasForeignKey(x => x.BlogsId);
            //modelBuilder.Entity<Post>().HasMany(x => x.BlogPosts).WithOne(x => x.Post).HasForeignKey(x => x.PostsId);
            //modelBuilder.Entity<BlogPost>().HasKey(x => new { x.BlogsId, x.PostsId });

            //modelBuilder.ApplyConfiguration(new MainClassConfiguration());
            //modelBuilder.ApplyConfiguration(new ExtraClassConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Identifier)
                .IsUnique();

            modelBuilder.Entity<ExtraClass>()
                .HasMany(ec => ec.Students)
                .WithMany(s => s.ExtraClasses)
                .UsingEntity<ExtraClassStudent>();

            modelBuilder.Entity<EcBookmark>()
                .HasMany(b => b.ExtraClasses)
                .WithMany(ec => ec.EcBookmarks)
                .UsingEntity<ExtraClassEcBookmark>();

        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ExtraClass> ExtraClasses { get; set; }
        public DbSet<MainClass> MainClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExtraClassStudent> ExtraClassesStudents { get; set; }
        public DbSet<EcBookmark> EcBookmarks { get; set; }
        public DbSet<ExtraClassEcBookmark> ExtraClassesEcBookmarks { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<AcademicProgress> AcademicProgresses { get; set; }
        public DbSet<AcademicTracker> AcademicTrackers { get; set; }
    }
}
