using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class MCQOptionConfiguration : IEntityTypeConfiguration<MCQOption>
    {
        public void Configure(EntityTypeBuilder<MCQOption> builder)
        {
            builder.ToTable("MCQOptions");

            builder.HasKey(o => o.OptionId);

            builder.Property(o => o.OptionText)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(o => o.IsCorrect)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(o => o.OrderNumber)
                .IsRequired();

            // Indexes
            builder.HasIndex(o => new { o.QuestionId, o.OrderNumber })
                .HasDatabaseName("IX_MCQOptions_Question_Order");

            // Relationships defined in ExamQuestionConfiguration
        }
    }
}
