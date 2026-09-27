using CENTER_MANAGEMENT_SYSTEM.Enums;

namespace CENTER_MANAGEMENT_SYSTEM.DTOs
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public decimal Grade { get; set; }
    }
    public class CreateEnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
    public class CompleteEnrollmentDTO
    {
        public decimal Grade { get; set; }
    }
}
