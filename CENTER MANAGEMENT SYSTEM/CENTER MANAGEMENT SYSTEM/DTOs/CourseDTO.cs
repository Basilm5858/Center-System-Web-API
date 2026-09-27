using CENTER_MANAGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CENTER_MANAGEMENT_SYSTEM.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationHours { get; set; }
        public decimal Fee { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public int EnrolledStudentsCount { get; set; }
    }
    public class CreateCourseDTO
    {
        public string Title { get; set; } = string.Empty;
        public int DurationHours { get; set; }
        public decimal Fee { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
    }
    public class UpdateCourseDTO
    {
        public string Title { get; set; } = string.Empty;
        public int DurationHours { get; set; }
        public decimal Fee { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public bool IsActive { get; set; }
    }
}
