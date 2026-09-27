using CENTER_MANAGEMENT_SYSTEM.Enums;
using System.ComponentModel.DataAnnotations;

namespace CENTER_MANAGEMENT_SYSTEM.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public int EnrolledCoursesCount { get; set; }
    }
    public class CreateStudentDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
    public class UpdateStudentDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
    public class StudentCourseDTO
    {
        public string CourseTitle { get; set; } = string.Empty;

        public string InstructorName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus Status { get; set; }

        public decimal? Grade { get; set; }
    }
}
