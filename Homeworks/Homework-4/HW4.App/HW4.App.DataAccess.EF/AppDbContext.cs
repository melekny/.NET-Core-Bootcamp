using HW4.App.DataAccess.EntityFramework.Configurations;
using HW4.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW4.App.DataAccess.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // Database Connection for Company & User Tables
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

    }
}