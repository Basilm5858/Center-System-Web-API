using System.ComponentModel.DataAnnotations;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string ?PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime RegistrationDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
