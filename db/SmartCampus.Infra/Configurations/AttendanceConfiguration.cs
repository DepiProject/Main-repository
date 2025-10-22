using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Table Name
            builder.ToTable("Attendance");

            // Primary Key
            builder.HasKey(a => a.AttendanceId);

            // Properties
            builder.Property(a => a.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20);

            // Indexes
            // منع تسجيل حضور مكرر لنفس الطالب في نفس المقرر في نفس اليوم
            builder.HasIndex(a => new { a.CourseId, a.StudentId, a.Date })
                .IsUnique()
                .HasDatabaseName("IX_Attendance_Course_Student_Date");

            // Relationships تم تعريفها في CourseConfiguration و StudentConfiguration
        }
    }
}
