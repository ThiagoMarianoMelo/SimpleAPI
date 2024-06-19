using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Entities;

namespace TestProject.Data.Context
{
    public class TestContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
