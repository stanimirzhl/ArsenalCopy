using System.ComponentModel.DataAnnotations;

namespace UniStuff.Data.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UniversityId { get; set; }
        public virtual University University { get; set; }

        public virtual ICollection<Major> Majors { get; set; } = new HashSet<Major>();
    }
}