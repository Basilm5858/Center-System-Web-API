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
    public class CourseCategoriesController : ControllerBase
    {
        private readonly My_AppContext _context;
        private readonly IMapper _mapper;
        public CourseCategoriesController(IMapper mapper)
        {
            _context = new My_AppContext();
            _mapper = mapper;
        }

        [HttpGet("EndPoint15")]
        public async Task<IActionResult> EndPoint15()
        {
            var category = await _context.CourseCategories
                .Include(x => x.Courses)
                .ToListAsync();

            if(category == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<List<CourseCategoryDTO>>(category);

            return Ok(res);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = _context.CourseCategories
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(res);
        }

        [HttpPost("EndPoint17")]
        public async Task<IActionResult> EndPoint17(CreateCourseCategoryDTO dto)
        {
            var res = _mapper.Map<CourseCategory>(dto);

            if (res == null)
            {
                return NotFound();
            }

            await _context.CourseCategories.AddAsync(res);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }
    }
}
