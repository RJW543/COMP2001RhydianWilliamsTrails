using CombinedTrailsApp.Models;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    // DbSet representing the "Profile" table
    public DbSet<UserVal> Profile { get; set; }

    // Constructor accepting DbContextOptions
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    // Method to configure the schema and properties for the "Profile" table
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring the "Profile" table with a specified schema ("CW2")
        modelBuilder.Entity<UserVal>()
            .ToTable("Profile", "CW2")
            .HasKey(u => u.Email); // Specify the primary key

        modelBuilder.Entity<UserVal>()
            .Property(u => u.Photo)
            .HasColumnName("Photo");

        // Configuring additional columns
        modelBuilder.Entity<UserVal>()
            .Property(u => u.FirstName)
            .HasColumnName("FirstName");

        modelBuilder.Entity<UserVal>()
            .Property(u => u.LastName)
            .HasColumnName("LastName");
    }
}