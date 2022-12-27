using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WeblogWebApp.Entities.Post;
using WeblogWebApp.Entities.Role;
using WeblogWebApp.Entities.User;

namespace WeblogWebApp.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory?> PostCategories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostMedia> PostMedias { get; set; }

        public DbSet<PostTag> PostTags { get; set; }
        
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
