using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities.Exams
{
    [Table("TrueFalseQuestion")]

    public class TrueFalseQuestion
    {

        [Key]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [Required]
        public bool CorrectAnswer { get; set; } // true false 

        // Navigation Properties
        public ExamQuestion Question { get; set; } = null!;
    }
}
