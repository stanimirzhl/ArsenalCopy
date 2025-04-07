using System.ComponentModel.DataAnnotations;

namespace UniStuff.Data.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; } = new HashSet<Faculty>();
    }
}