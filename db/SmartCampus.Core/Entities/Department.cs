using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.Core.Entities
{
    [Table("Departments")]
    public class Department
    {


        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Building { get; set; }

        // Foreign Key - رئيس القسم
        public int? HeadId { get; set; }

        // Navigation Properties
        [ForeignKey("HeadId")]
        public Instructor? Head { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
