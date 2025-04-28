using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Answer_Text { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int Question_Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Player_Answer> Player_Answers { get; set; } = new HashSet<Player_Answer>();
    }
}