using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities.Exams
{
    [Table("ExamAnswers")]
    public class ExamAnswer
    {

        [Key]
        public int AnswerId { get; set; }

        // Foreign Key - Submission
        [Required]
        public int SubmissionId { get; set; }

        // Foreign Key - Question
        [Required]
        public int QuestionId { get; set; }



        // الإجابة (يختلف حسب نوع السؤال)
        [Column(TypeName = "nvarchar(max)")]

        public bool? TrueFalseAnswer { get; set; } //  True/False
        public int? SelectedOptionId { get; set; } // MCQ - Selected Option
        public bool? IsCorrect { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PointsAwarded { get; set; }

        // Navigation Properties

        [ForeignKey("SubmissionId")]
        public ExamSubmission Submission { get; set; } = null!;

        [ForeignKey("QuestionId")]
        public ExamQuestion Question { get; set; } = null!;

        [ForeignKey("SelectedOptionId")]
        public MCQOption? SelectedOption { get; set; }

    }
}
