using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class ExamSubmissionConfiguration : IEntityTypeConfiguration<ExamSubmission>
    {
        public void Configure(EntityTypeBuilder<ExamSubmission> builder)
        {
            builder.ToTable("ExamSubmissions");

            builder.HasKey(s => s.SubmissionId);

            builder.Property(s => s.StartedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.Score)
                .HasColumnType("decimal(5,2)");

            builder.Property(s => s.IsGraded)
                .HasDefaultValue(false);

           

            // Indexes
            builder.HasIndex(s => new { s.ExamId, s.StudentId })
                .IsUnique()
                .HasDatabaseName("IX_ExamSubmissions_Exam_Student");

            builder.HasIndex(s => s.StudentId)
                .HasDatabaseName("IX_ExamSubmissions_StudentId");

            // Relationships
            builder.HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.GradedByInstructor)
                .WithMany()
                .HasForeignKey(s => s.GradedBy)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(s => s.Answers)
                .WithOne(a => a.Submission)
                .HasForeignKey(a => a.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
