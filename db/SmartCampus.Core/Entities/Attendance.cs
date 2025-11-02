// test something
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities
{
    [Table("Attendances")]

    public class Attendance
    {

        [Key]
        public int AttendanceId { get; set; }

        // Foreign Key - Course
        [Required]
        public int CourseId { get; set; }

        // Foreign Key - Student
        [Required]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = string.Empty; // Present, Absent

     

        // Navigation Properties
        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;

        [ForeignKey("StudentId")]
        public Student Student { get; set; } = null!;
    }
}

