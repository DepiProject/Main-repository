using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartCampus.Core.Entities
{

    [Table("Notifications")]
    public class Notification
    {

        [Key]
        public int NotificationId { get; set; }

        //Foreign Key - User 
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // GradeUpdate, AttendanceWarning,Enrolled


        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Message { get; set; } = string.Empty;



        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
