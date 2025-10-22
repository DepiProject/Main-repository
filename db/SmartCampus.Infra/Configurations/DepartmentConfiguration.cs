using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department>builder)
        {



            // Table Name
            builder.ToTable("Departments");

            // Primary Key
            builder.HasKey(d => d.DepartmentId);

            // Properties
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Building)
                .HasMaxLength(100);

            // Indexes
            builder.HasIndex(d => d.Name)
                .IsUnique()
                .HasDatabaseName("IX_Departments_Name");

            // Relationships
            // Department → Head (Instructor) - Many-to-One (optional)
            builder.HasOne(d => d.Head)
                .WithMany(i => i.ManagedDepartments)
                .HasForeignKey(d => d.HeadId)
                .OnDelete(DeleteBehavior.SetNull);

            // Department → Students (One-to-Many)
            builder.HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department → Instructors (One-to-Many)
            builder.HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department → Courses (One-to-Many)
            builder.HasMany(d => d.Courses)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
    


    
}
