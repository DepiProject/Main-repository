using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartCampus.Core.Entities.Exams
{
    [Table("MCQOptions")]
    public class MCQOption
    {

        [Key]
        public int OptionId { get; set; }

        // Foreign Key - ExamQuestion
        [Required]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(255)]
        public string OptionText { get; set; } = string.Empty;

        [Required]
        public bool IsCorrect { get; set; } = false;

        public int OrderNumber { get; set; } // ترتيب الخيار (A, B, C, D)

        // Navigation Properties
        [ForeignKey("QuestionId")]
        public ExamQuestion Question { get; set; } = null!;
    }
}
