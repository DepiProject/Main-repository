using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartCampus.Core.Entities;

namespace SmartCampus.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Table name
            builder.ToTable("Notifications");

            // Primary key
            builder.HasKey(n => n.NotificationId);

            // Properties
            builder.Property(n => n.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(n => n.SentAt)
                   .HasDefaultValueSql("GETUTCDATE()"); // auto set UTC time

            // Relationships
            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notifications) // make sure User has ICollection<Notification>
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // optional, depends on your logic
        }
    }

}
