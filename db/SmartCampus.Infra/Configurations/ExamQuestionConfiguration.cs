using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions");

            builder.HasKey(q => q.QuestionId);

            builder.Property(q => q.QuestionText)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(q => q.Points)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(q => q.OrderNumber)
                .IsRequired();

            // Indexes
            builder.HasIndex(q => new { q.ExamId, q.OrderNumber })
                .HasDatabaseName("IX_ExamQuestions_Exam_Order");

            // Relationships
            builder.HasMany(q => q.MCQOptions)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.TrueFalseQuestion)
                .WithOne(tf => tf.Question)
                .HasForeignKey<TrueFalseQuestion>(tf => tf.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
