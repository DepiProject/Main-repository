using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.Core.Entities.Exams
{

    [Table("ExamQuestions")]
    public class ExamQuestion
    {

        [Key]
        public int QuestionId { get; set; }

        // Foreign Key - Exam
        [Required]
        public int ExamId { get; set; }

        // Foreign Key - QuestionType
        [Required]
        public int TypeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Points { get; set; } // question Degree

        public int OrderNumber { get; set; } // ترتيب السؤال 

        // Navigation Properties
        [ForeignKey("ExamId")]
        public Exam Exam { get; set; } = null!;

        [ForeignKey("TypeId")]
        public QuestionType QuestionType { get; set; } = null!;

        // Specific Question Types 
        public ICollection<MCQOption> MCQOptions { get; set; } = new List<MCQOption>();
        public TrueFalseQuestion? TrueFalseQuestion { get; set; }
       

        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();

    }
}
