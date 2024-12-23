using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DB
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<SocialLinks> SocialLinks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasIndex(u => u.Email)
                    .IsUnique();
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.Role)
                    .IsRequired();
                entity.Property(u => u.Verified)
                    .HasDefaultValue(false);
                entity.Property(u => u.CreatedAt)
                    .HasDefaultValue("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(u => u.Title)
                    .HasMaxLength(500);
                entity.Property(u => u.Description)
                    .HasMaxLength(2000);
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength (1000);
            });
            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);
                entity.Property(e => e.Enterprise)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.StartDate)
                    .IsRequired();
            });
            //modelBuilder.Entity<SocialLinks>();
            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired();
                entity.HasIndex(u => u.Name)
                    .IsUnique();
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(p => p.Content)
                 .IsRequired()
                 .HasMaxLength(5000);
                entity.Property(p => p.Likes)
                    .HasDefaultValue(0);
                entity.Property(p => p.CreatedAt)
                    .HasDefaultValue("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(c => c.Content)
                    .IsRequired()
                    .HasMaxLength(5000);
                entity.Property (c => c.Likes)
                    .HasDefaultValue(0);
                entity.Property(c => c.CreatedAt)
                    .HasDefaultValue("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
                entity.Property(p => p.WasEdited)
                    .HasDefaultValue(false);
            });
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

        }

    }
}
 