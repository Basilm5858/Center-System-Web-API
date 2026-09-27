using System.ComponentModel.DataAnnotations;

namespace CENTER_MANAGEMENT_SYSTEM.DTOs
{
    public class CourseCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CourseCount { get; set; }

    }
    public class CreateCourseCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
    public class UpdateCourseCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
