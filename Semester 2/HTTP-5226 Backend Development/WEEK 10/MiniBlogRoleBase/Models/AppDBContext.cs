using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniBlogRoleBase.Models;
using MiniBlogRoleBase;

namespace MiniBlogRoleBase.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        // your domain DbSets go here
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // important: keeps Identity's table config

            // custom configs, e.g.
            // builder.Entity<ApplicationUser>().Property(u => u.FullName).HasMaxLength(100);
        }
    }
}