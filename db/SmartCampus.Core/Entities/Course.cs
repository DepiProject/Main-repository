using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CourseCode { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        // Foreign Key - Department
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Range(1, 6)]
        public int Credits { get; set; }


        // Foreign Key - Instructor
        [Required]
        public int InstructorId { get; set; }

        [MaxLength(255)]
        public string? Prerequisites { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    }
}
