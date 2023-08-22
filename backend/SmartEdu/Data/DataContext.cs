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

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //modelBuilder.Entity<Blog>().HasMany(x => x.BlogPosts).WithOne(x => x.Blog).HasForeignKey(x => x.BlogsId);
            //modelBuilder.Entity<Post>().HasMany(x => x.BlogPosts).WithOne(x => x.Post).HasForeignKey(x => x.PostsId);
            //modelBuilder.Entity<BlogPost>().HasKey(x => new { x.BlogsId, x.PostsId });
            
        }
        
    }
}
