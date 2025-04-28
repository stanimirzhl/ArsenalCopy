using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int Amount { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public virtual ICollection<LifeLine> LifeLines { get; set; } = new HashSet<LifeLine>();
    }
}