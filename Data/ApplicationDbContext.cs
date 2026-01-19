using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Phone)
                .IsUnique();

            // Soft delete global
            modelBuilder.Entity<Contact>()
                .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
