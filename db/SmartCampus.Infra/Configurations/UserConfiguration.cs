using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
  
    
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                // Configuration logic here  

                // Table Name
                builder.ToTable("Users");

                // Primary Key
                builder.HasKey(u => u.UserId);

                // Properties
                builder.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.Role)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(u => u.MustChangePassword)
                .HasDefaultValue(true);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            builder.Property(u => u.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                builder.Property(u => u.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                // Indexes
                builder.HasIndex(u => u.Username)
                    .IsUnique()
                    .HasDatabaseName("IX_Users_Username");

                builder.HasIndex(u => u.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_Users_Email");

                // Relationships
                // User → Student (One-to-Zero-or-One)
                builder.HasOne(u => u.Student)
                    .WithOne(s => s.User)
                    .HasForeignKey<Student>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // User → Instructor (One-to-Zero-or-One)
                builder.HasOne(u => u.Instructor)
                    .WithOne(i => i.User)
                    .HasForeignKey<Instructor>(i => i.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // User → Notifications (One-to-Many)
                builder.HasMany(u => u.Notifications)
                    .WithOne(n => n.User)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }


