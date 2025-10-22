using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities
{
    [Table("Grades")]
    public class Grade
    {

        [Key]
        public int GradeId { get; set; }

        // Foreign Key - Enrollment
        [Required]
        public int EnrollmentId { get; set; }


        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [Required]
        [MaxLength(5)]
        public string GradeLetter { get; set; } = string.Empty; // A+, A, B+, etc

        [Required]
        public int EnteredBy { get; set; }    // Foreign Key - Instructor (الذي أدخل الدرجة)

        public DateTime EnteredAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("EnrollmentId")]
        public Enrollment Enrollment { get; set; } = null!;

        [ForeignKey("EnteredBy")]
        public Instructor EnteredByInstructor { get; set; } = null!;

    }
}
