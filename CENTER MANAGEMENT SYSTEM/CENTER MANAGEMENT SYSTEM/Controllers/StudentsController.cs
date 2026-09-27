using AutoMapper;
using CENTER_MANAGEMENT_SYSTEM.DTOs;
using CENTER_MANAGEMENT_SYSTEM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CENTER_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly My_AppContext _context;
        private readonly IMapper _mapper;
        public StudentsController(IMapper mapper)
        {
            _context = new My_AppContext();
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _context.CourseCategories
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(res);
        }

        [HttpPost("EndPoint18")]
        public async Task<IActionResult> EndPoint18(CreateStudentDTO dto)
        {
            var res = _mapper.Map<Student>(dto);

            if (res == null)
            {
                return NotFound();
            }


            await _context.Students.AddAsync(res);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpGet("EndPoint25")]
        public async Task<IActionResult> EndPoint25(int id)
        {
            var studentExists = await _context.Students
                .AnyAsync(x => x.Id == id);

            if (!studentExists)
            {
                return NotFound("Student Not Found");
            }

            var courses = await _context.Enrollments
                .Where(x => x.StudentId == id)
                .Select(x => new StudentCourseDTO
                {
                    CourseTitle = x.Course.Title,
                    InstructorName = x.Course.Instructor.FullName,
                    EnrollmentDate = x.EnrollmentDate,
                    Status = x.Status,
                    Grade = x.Grade
                }).ToListAsync();

            return Ok(courses);
        }
    }
}
