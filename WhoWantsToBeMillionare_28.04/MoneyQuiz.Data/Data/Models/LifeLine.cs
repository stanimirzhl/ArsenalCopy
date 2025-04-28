using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class LifeLine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Used_On_Question_Id { get; set; }
        public virtual Question Question { get; set; }
        [Required]
        public int Player_Game_Session_Id { get; set; }
        public virtual Player_Game_Session Player_Game_Session { get; set; }
    }
}