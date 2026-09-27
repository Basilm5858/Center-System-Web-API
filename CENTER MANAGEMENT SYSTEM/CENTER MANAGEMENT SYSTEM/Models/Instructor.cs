using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>(); 
    }
}

