using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Table Name
            builder.ToTable("Grades");

            // Primary Key
            builder.HasKey(g => g.GradeId);

            // Properties
            builder.Property(g => g.Score)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(g => g.GradeLetter)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(g => g.EnteredAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(g => g.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(g => g.EnrollmentId)
                .IsUnique()
                .HasDatabaseName("IX_Grades_EnrollmentId");

            
        }
    }


}
