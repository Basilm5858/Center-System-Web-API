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
    public class CoursesController : ControllerBase
    {
        private readonly My_AppContext _context;
        private readonly IMapper _mapper;
        public CoursesController(IMapper mapper)
        {
            _context = new My_AppContext();
            _mapper = mapper;
        }

        [HttpGet("EndPoint1")]
        public async Task<IActionResult> EndPoint1(decimal fee)
        {
            var course = await _context.Courses
                .Where(x => x.Fee > fee)
                .ToListAsync();

            if (course == null)
            {
                return BadRequest("Not Found");
            }
            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> EndPoint2(decimal min, decimal max)
        {
            var course = await _context.Courses
                .Where(x => x.Fee >= min && x.Fee <= max)
                .ToListAsync();

            if (course == null)
            {
                return BadRequest("Not Found");
            }
            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint3")]
        public async Task<IActionResult> EndPoint3(string title)
        {
            var course = await _context.Courses
                .Where(x => x.Title.Contains(title))
                .ToListAsync();

            if(course == null)
            {
                return BadRequest("Not Found");
            }

            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint4")]
        public async Task<IActionResult> EndPoint4()
        {
            var course = await _context.Courses
                .FirstAsync();

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint5")]
        public async Task<IActionResult> EndPoint5()
        {
            var course = await _context.Courses
                .Where(x => x.IsActive == true)
                .FirstAsync();

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint6")]
        public async Task<IActionResult> EndPoint6(int id)
        {
            var course = await _context.Courses
                .Include(x => x.CourseCategory)
                .Include(x => x.Instructor)
                .Include(x => x.Enrollments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }


        [HttpGet("EndPoint7")]
        public async Task<IActionResult> EndPoint7()
        {
            var course = await _context.Courses
                .LastAsync();

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }


        [HttpGet("EndPoint8")]
        public async Task<IActionResult> EndPoint8(int id)
        {
            var course = await _context.Courses
                .AnyAsync(x => x.Id == id);

            if (course == false)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }


        [HttpGet("EndPoint9")]
        public async Task<IActionResult> EndPoint9()
        {
            var course = await _context.Courses
                .AllAsync(x => x.IsActive == true);

            if (course == false)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint10")]
        public async Task<IActionResult> EndPoint10()
        {
            var course = await _context.Courses
                .Select(x => x.Title)
                .ToListAsync();

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint11")]
        public async Task<IActionResult> EndPoint11()
        {
            var course = await _context.Courses
                .OrderBy(x => x.Title)
                .ToListAsync();

            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint12")]
        public async Task<IActionResult> EndPoint12()
        {
            var course = await _context.Courses
                .MinAsync(x => x.Fee);

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint13")]
        public async Task<IActionResult> EndPoint13()
        {
            var course = await _context.Courses
                .AverageAsync(x => x.Fee);

            var res = _mapper.Map<CourseDTO>(course);

            return Ok(res);
        }

        [HttpGet("EndPoint14")]
        public async Task<IActionResult> EndPoint14(int pageno, int pagesize)
        {
            var course = _context.Courses
                .Skip((pageno - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync();

            if (pageno <= 0 || pagesize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

            var res = _mapper.Map<List<CourseDTO>>(course);

            return Ok(res);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _context.Courses.FindAsync(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost("EndPoint19")]
        public async Task<IActionResult> EndPoint19(CreateCourseDTO dto)
        {
            var category = _context.CourseCategories
                .FirstOrDefaultAsync(x => x.Id == dto.CategoryId);

            if(category == null)
            {
                return NotFound("Category Not Found");
            }

            var instructor = _context.Instructors
                .FirstOrDefaultAsync(x => x.Id == dto.InstructorId);

            if (instructor == null)
            {
                return NotFound("Instructor Not Found");
            }

            if(dto.Fee <= 0)
            {
                return NotFound("Fee must be greater than 0");
            }
            if (dto.Capacity <= 0)
            {
                return NotFound("Capacity must be greater than 0");
            }

            var res = _mapper.Map<Course>(dto);

            if(res == null)
            {
                return BadRequest();
            }

            await _context.Courses.AddAsync(res);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpPut("EndPoint20")]
        public async Task<IActionResult> EndPoint20(int id, UpdateCourseDTO dto)
        {
            var course = _context.Courses
               .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound("Course Not Found");
            }

            var category = _context.CourseCategories
                .FirstOrDefaultAsync(x => x.Id == dto.CategoryId);

            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            var instructor = _context.Instructors
                .FirstOrDefaultAsync(x => x.Id == dto.InstructorId);

            if (instructor == null)
            {
                return NotFound("Instructor Not Found");
            }

            if (dto.Fee <= 0)
            {
                return NotFound("Fee must be greater than 0");
            }

            if (dto.Capacity <= 0)
            {
                return NotFound("Capacity must be greater than 0");
            }

            var res = _mapper.Map(dto, course);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }









    }
}
