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

    modelBuilder.Entity<UserVal>()
        .ToTable("Profile", "CW2")
        .HasKey(u => u.Email);

    modelBuilder.Entity<UserVal>()
        .Property(u => u.Photo)
        .HasColumnName("Photo");

    // ... other properties ...

    modelBuilder.Entity<UserVal>()
        .Property(u => u.AboutMe)
        .HasColumnName("AboutMe");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.LocationID)
        .HasColumnName("LocationID");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.Units)
        .HasColumnName("Units");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.ActivityTimePref)
        .HasColumnName("ActivityTimePref");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.Height)
        .HasColumnName("Height");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.Weight)
        .HasColumnName("Weight");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.Dob)
        .HasColumnName("Dob");

    modelBuilder.Entity<UserVal>()
        .Property(u => u.LanguageID)
        .HasColumnName("LanguageID");
    }
}