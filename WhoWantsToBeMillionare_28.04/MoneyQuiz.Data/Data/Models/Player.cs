using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Player_Game_Session> Player_Game_Sessions { get; set; } = new HashSet<Player_Game_Session>();
    }
}