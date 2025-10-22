using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities
{
    [Table("Instructors")]
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        // Foreign Key - Department
        [Required]
        public int DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Department> ManagedDepartments { get; set; } = new List<Department>(); // الأقسام اللي هو رئيس ليها
        public ICollection<Grade> GradesEntered { get; set; } = new List<Grade>(); // الدرجات اللي أدخلها




    }
}
