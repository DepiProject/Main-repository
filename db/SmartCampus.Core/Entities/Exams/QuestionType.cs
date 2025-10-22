using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCampus.Core.Entities.Exams
{
    [Table("QuestionType")]
    public class QuestionType
    {

        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty; // MCQ, TrueFalse



        [MaxLength(255)]
        public string? Description { get; set; }

        public ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();
    }
}
