using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities.Exams
{

    [Table("Exams")]
    public class Exam
    {

        [Key]
        public int ExamId { get; set; }

        // Foreign Key - Course
        [Required]
        public int CourseId { get; set; }


        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty; //  "Midterm Exam", "Final Exam"

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPoints { get; set; } // إجمالي الدرجات


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;

        public ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();
        public ICollection<ExamSubmission> Submissions { get; set; } = new List<ExamSubmission>();

    }
}
