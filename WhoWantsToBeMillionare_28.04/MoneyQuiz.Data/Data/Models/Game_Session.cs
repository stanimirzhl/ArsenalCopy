using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Game_Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public int Final_Amount { get; set; }

        public virtual ICollection<Player_Game_Session> Player_Game_Sessions { get; set; } = new HashSet<Player_Game_Session>();
    }
}