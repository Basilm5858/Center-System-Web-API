using System.ComponentModel.DataAnnotations;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class CourseCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string ?Description { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
