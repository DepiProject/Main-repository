using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities.Exams
{
    [Table("ExamSubmissions")]
    public class ExamSubmission
    {

        [Key]
        public int SubmissionId { get; set; }

        [Required]
        public int ExamId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? SubmittedAt { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public decimal? Score { get; set; } // الدرجة (null إذا لم يتم التصحيح)

        public bool IsGraded { get; set; } = false; // هل تم التصحيح؟

        public int? GradedBy { get; set; } // Instructor

                                         
         // Navigation Properties

        [ForeignKey("ExamId")]
        public Exam Exam { get; set; } = null!;

        [ForeignKey("StudentId")]
        public Student Student { get; set; } = null!;

        [ForeignKey("GradedBy")]
        public Instructor? GradedByInstructor { get; set; }

        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();

    }
}
