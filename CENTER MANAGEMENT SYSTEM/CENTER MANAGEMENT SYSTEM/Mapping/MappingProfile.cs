using AutoMapper;
using CENTER_MANAGEMENT_SYSTEM.DTOs;
using CENTER_MANAGEMENT_SYSTEM.Models;

namespace CENTER_MANAGEMENT_SYSTEM.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CourseCategory

            CreateMap<CourseCategory, CourseCategoryDTO>()
                .ForMember(
                x => x.CourseCount,
                x => x.MapFrom(src => src.Courses.Count)
                );
            CreateMap<CreateCourseCategoryDTO, CourseCategory>();
            CreateMap<UpdateCourseCategoryDTO, CourseCategory>();

            // Course

            CreateMap<Course, CourseDTO>()
                .ForMember(
                x => x.CategoryName,
                opt => opt.MapFrom(x => x.CourseCategory.Name)
                ).ForMember(
                x => x.InstructorName,
                opt => opt.MapFrom(x => x.Instructor.FullName)
                ).ForMember(
                x => x.EnrolledStudentsCount,
                opt => opt.MapFrom(x => x.Enrollments.Count)
                );

            CreateMap<CreateCourseDTO, Course>();
            CreateMap<UpdateCourseDTO, Course>();

            // Enrollment

            CreateMap<Enrollment, EnrollmentDTO>()
                .ForMember(
                x => x.StudentName,
                x => x.MapFrom(src => src.Student.FullName)
                ).ForMember(
                x => x.CourseTitle,
                x => x.MapFrom(src => src.Course.Title)
                );
            CreateMap<CreateEnrollmentDTO, Enrollment>();
            CreateMap<CompleteEnrollmentDTO, Enrollment>();

            // Instructor

            CreateMap<Instructor, InstructorDTO>()
                .ForMember(
                x => x.CourseCount,
                x => x.MapFrom(src => src.Courses.Count)
                );
            CreateMap<CreateInstructorDTO, Instructor>();
            CreateMap<UpdateInstructorDTO, Instructor>();

            // Student

            CreateMap<Student, StudentDTO>()
                .ForMember(
                x => x.EnrolledCoursesCount,
                x => x.MapFrom(src => src.Enrollments.Count)
                );
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();


        }
    }
}
