using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class ExamAnswerConfiguration : IEntityTypeConfiguration<ExamAnswer>
    {
        public void Configure(EntityTypeBuilder<ExamAnswer> builder)
        {
            builder.ToTable("ExamAnswers");

            builder.HasKey(a => a.AnswerId);

            //builder.Property(a => a.AnswerText)
            //    .HasColumnType("nvarchar(max)");

            builder.Property(a => a.PointsAwarded)
                .HasColumnType("decimal(5,2)");

            // Indexes
            builder.HasIndex(a => new { a.SubmissionId, a.QuestionId })
                .IsUnique()
                .HasDatabaseName("IX_ExamAnswers_Submission_Question");

            // Relationships
            builder.HasOne(a => a.SelectedOption)
                .WithMany()
                .HasForeignKey(a => a.SelectedOptionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
