using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            // Table Name
            builder.ToTable("Instructors");

            // Primary Key
            builder.HasKey(i => i.InstructorId);

            // Properties
            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.ContactNumber)
                .HasMaxLength(20);

            builder.Property(i => i.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(i => i.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(i => i.UserId)
                .IsUnique()
                .HasDatabaseName("IX_Instructors_UserId");

            // Relationships
            // Instructor → Courses (One-to-Many)
            builder.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Instructor → Grades (One-to-Many)
            builder.HasMany(i => i.GradesEntered)
                .WithOne(g => g.EnteredByInstructor)
                .HasForeignKey(g => g.EnteredBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
