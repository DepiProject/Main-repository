using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities.Exams;

namespace SmartCampus.Data.Configurations
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionTypes");

            builder.HasKey(qt => qt.TypeId);

            builder.Property(qt => qt.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(qt => qt.Description)
                .HasMaxLength(255);

            // Index
            builder.HasIndex(qt => qt.Name)
                .IsUnique()
                .HasDatabaseName("IX_QuestionTypes_Name");

            // Seed Data (بيانات افتراضية)
            builder.HasData(
                new QuestionType { TypeId = 1, Name = "MCQ", Description = "Multiple Choice Question" },
                new QuestionType { TypeId = 2, Name = "TrueFalse", Description = "True/False Question" }
                
            );

            // Relationships
            builder.HasMany(qt => qt.Questions)
                .WithOne(q => q.QuestionType)
                .HasForeignKey(q => q.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
