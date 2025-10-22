using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;
namespace SmartCampus.Data.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // Table Name
            builder.ToTable("Enrollments");

            // Primary Key
            builder.HasKey(e => e.EnrollmentId);

            // Properties
            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Enrolled");

            builder.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            // منع تسجيل الطالب في نفس المقرر مرتين
            builder.HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique()
                .HasDatabaseName("IX_Enrollments_Student_Course");

       
         
        }
    }


}
