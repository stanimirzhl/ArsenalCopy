using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player_Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int Player_Session_Id { get; set; }
        public virtual Player_Game_Session Player_Game_Session { get; set; }
        [Required]
        public int Answer_Id { get; set; }
        public virtual Answer Answer { get; set; }
    }
}