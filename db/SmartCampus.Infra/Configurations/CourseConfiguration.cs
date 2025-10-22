using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table Name
            builder.ToTable("Courses");

            // Primary Key
            builder.HasKey(c => c.CourseId);

            // Properties
            builder.Property(c => c.CourseCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Credits)
                .IsRequired();

            builder.Property(c => c.Prerequisites)
                .HasMaxLength(255);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(c => c.CourseCode)
                .IsUnique()
                .HasDatabaseName("IX_Courses_CourseCode");

            // Relationships
            // Course → Enrollments (One-to-Many)
            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);  // منع الحذف المتسلسل 

            // Course → Attendances (One-to-Many)
            builder.HasMany(c => c.Attendances)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
