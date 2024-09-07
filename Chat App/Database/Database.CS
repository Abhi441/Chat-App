using Chat_App.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chat_App.Database
{
    public class Database1 : DbContext
    {
        public Database1(DbContextOptions<Database1> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; } // Changed property name to "Users" for consistency

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUsers"); // Specifies the table name in the database

                entity.HasKey(e => e.Id); // Specifies the primary key

                entity.Property(e => e.UserName)
                      .HasMaxLength(100) // Example constraint: max length of 100 characters
                      .IsRequired(false); // Since it's nullable
            });
        }
    }
}
