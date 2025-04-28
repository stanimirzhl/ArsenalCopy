using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player_Game_Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Player_Id { get; set; }
        public virtual Player Player { get; set; }
        [Required]
        public int Session_Id { get; set; }
        public virtual Game_Session Session { get; set; }

        public virtual ICollection<Player_Answer> Player_Answers { get; set; } = new HashSet<Player_Answer>();
        public virtual ICollection<LifeLine> LifeLines { get; set; } = new HashSet<LifeLine>();

    }
}