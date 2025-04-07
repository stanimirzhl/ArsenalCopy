using System.ComponentModel.DataAnnotations;

namespace UniStuff.Data.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}