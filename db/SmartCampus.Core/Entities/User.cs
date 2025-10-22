using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string PasswordHash { get; set; } = string.Empty;


        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]

        public string Role { get; set; } = string.Empty; // Admin, Student, Instructor

        public bool MustChangePassword { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public Student? Student { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    }
}
