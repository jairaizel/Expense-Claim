// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ExpenseClaimAPI.Models;

namespace ExpenseClaimAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between User and Claim
            modelBuilder.Entity<Claim>()
                        .HasOne(c => c.User)
                        .WithMany(u => u.Claims)
                        .HasForeignKey(c => c.UserId);
        }
    }
}
