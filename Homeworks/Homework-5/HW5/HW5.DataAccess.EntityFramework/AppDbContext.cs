using HW5.DataAccess.EntityFramework.Configurations;
using HW5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW5.DataAccess.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Database Connection for the Posts Table.
        public DbSet<Post> Posts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
    }
}