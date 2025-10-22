using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.Core.Entities
{
    [Table("Enrollments")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        // Foreign Key - Student
        [Required]
        public int StudentId { get; set; }

        // Foreign Key - Course
        [Required]
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Enrolled"; // Enrolled, Dropped, Completed

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("StudentId")]
        public Student Student { get; set; } = null!;

        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;
    }
}
