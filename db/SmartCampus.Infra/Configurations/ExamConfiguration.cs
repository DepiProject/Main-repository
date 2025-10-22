using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(e => e.ExamId);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ExamDate)
                .IsRequired();

            builder.Property(e => e.Duration)
                .IsRequired();

            builder.Property(e => e.TotalPoints)
                .HasColumnType("decimal(5,2)");

           

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(e => e.CourseId)
                .HasDatabaseName("IX_Exams_CourseId");

            builder.HasIndex(e => e.ExamDate)
                .HasDatabaseName("IX_Exams_ExamDate");

            // Relationships
            builder.HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Questions)
                .WithOne(q => q.Exam)
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Submissions)
                .WithOne(s => s.Exam)
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
