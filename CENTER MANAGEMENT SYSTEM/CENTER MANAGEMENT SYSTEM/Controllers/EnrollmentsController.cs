using AutoMapper;
using CENTER_MANAGEMENT_SYSTEM.DTOs;
using CENTER_MANAGEMENT_SYSTEM.Enums;
using CENTER_MANAGEMENT_SYSTEM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CENTER_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly My_AppContext _context;
        private readonly IMapper _mapper;
        public EnrollmentsController(IMapper mapper)
        {
            _context = new My_AppContext();
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _context.Enrollments
                .FirstOrDefaultAsync(x => x.Id == id);
            if(res == null)
            {
                return NotFound("enrollment not found");
            }
            return Ok(res);
        }

        [HttpPost("EndPoint21")]
        public async Task<IActionResult> EndPoint21(CreateEnrollmentDTO dto)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == dto.StudentId);

            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(x => x.Id == dto.CourseId);

            if (course == null)
            {
                return NotFound("Course Not Found");
            }

            if (!course.IsActive)
            {
                return BadRequest("Course is not active");
            }

            var alreadyEnrolled = await _context.Enrollments
                .AnyAsync(x =>
                    x.CourseId == dto.CourseId &&
                    x.StudentId == dto.StudentId);

            if (alreadyEnrolled)
            {
                return BadRequest("Student is already enrolled in this course");
            }

            var activeEnrollments = await _context.Enrollments
                .CountAsync(x =>
                    x.CourseId == dto.CourseId &&
                    x.Status == EnrollmentStatus.Active);

            if (activeEnrollments >= course.Capacity)
            {
                return BadRequest("Capacity is not available");
            }

            var enrollment = _mapper.Map<Enrollment>(dto);

            enrollment.Status = EnrollmentStatus.Active;
            enrollment.EnrollmentDate = DateTime.Now;

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            enrollment.Student = student;
            enrollment.Course = course;

            var res = _mapper.Map<EnrollmentDTO>(enrollment);

            return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, res);
        }

        [HttpPut("EndPoint22")]
        public async Task<IActionResult> EndPoint22(int id, CompleteEnrollmentDTO dto)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (enrollment == null)
            {
                return NotFound("Enrollment Not Found");
            }

            if (enrollment.Status != EnrollmentStatus.Active)
            {
                return BadRequest("Enrollment is already completed or cancelled");
            }

            if (dto.Grade < 0 || dto.Grade > 100)
            {
                return BadRequest("Grade must be between 0 and 100");
            }

            enrollment.Grade = dto.Grade;
            enrollment.Status = EnrollmentStatus.Completed;

            await _context.SaveChangesAsync();

            return Ok("Enrollment completed successfully");
        }

        [HttpPut("EndPoint23")]
        public async Task<IActionResult> EndPoint23(int id)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (enrollment == null)
            {
                return NotFound("Enrollment Not Found");
            }

            if (enrollment.Status != EnrollmentStatus.Active)
            {
                return BadRequest("Enrollment is already completed or cancelled");
            }

            enrollment.Status = EnrollmentStatus.Cancelled;

            await _context.SaveChangesAsync();

            return Ok("Enrollment Cancelled successfully");
        }

        [HttpDelete("EndPoint24")]
        public async Task<IActionResult> EndPoint24(int id)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(x => x.Id == id);

            if(enrollment == null)
            {
                return NotFound();
            }

            if (enrollment.Status == EnrollmentStatus.Active 
                || enrollment.Status == EnrollmentStatus.Completed)
            {
                return BadRequest("Enrollment is already completed or cancelled");
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
