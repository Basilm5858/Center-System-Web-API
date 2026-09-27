using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Range (1,200,ErrorMessage = " The duration hours must be between 1 and 200")]
        public int DurationHours { get; set; }
        [Required]
        [Range(0.01,int.MaxValue)]
        public decimal Fee { get; set; }
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public CourseCategory CourseCategory { get; set; }
        [ForeignKey("CourseCategory")]
        public int CourseCategoryId { get; set; }
        public Instructor Instructor { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
