using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>

    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Table Name
            builder.ToTable("Students");

            // Primary Key
            builder.HasKey(s => s.StudentId);

            // Properties
            builder.Property(s => s.StudentCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ContactNumber)
                .HasMaxLength(20);

            builder.Property(s => s.Level)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(s => s.StudentCode)
                .IsUnique()
                .HasDatabaseName("IX_Students_StudentCode");

            builder.HasIndex(s => s.UserId)
                .IsUnique()
                .HasDatabaseName("IX_Students_UserId");

            // Relationships تم تعريفها في UserConfiguration و DepartmentConfiguration

            // Student → Enrollments (One-to-Many)
            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Student → Attendances (One-to-Many)
            builder.HasMany(s => s.Attendances)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
