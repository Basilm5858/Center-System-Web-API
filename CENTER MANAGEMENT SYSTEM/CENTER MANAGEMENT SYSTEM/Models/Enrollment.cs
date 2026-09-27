using CENTER_MANAGEMENT_SYSTEM.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        public EnrollmentStatus Status { get; set; }
        [Range(0, 100, ErrorMessage = "The grade must be between 0 and 100")]
        public decimal? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
    }
}
