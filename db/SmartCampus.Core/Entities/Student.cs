using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.Core.Entities
{
    [Table("Students")]
    public class Student
    {

        [Key]
        public int StudentId { get; set; }

        // Foreign Key - User
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string StudentCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        // Foreign Key - Department
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Level { get; set; } = string.Empty; // Level 1, Level 2, Level 3, Level 4

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
