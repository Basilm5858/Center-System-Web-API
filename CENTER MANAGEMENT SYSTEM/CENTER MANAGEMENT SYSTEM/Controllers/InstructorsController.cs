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
    public class InstructorsController : ControllerBase
    {
        private readonly My_AppContext _context;
        private readonly IMapper _mapper;
        public InstructorsController(IMapper mapper)
        {
            _context = new My_AppContext();
            _mapper = mapper;
        }

        [HttpGet("EndPoint16")]
        public async Task<IActionResult> EndPoint16()
        {
            var instructor = await _context.Instructors
                .Include(x => x.Courses)
                .ToListAsync();

            if (instructor == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<List<InstructorDTO>>(instructor);

            return Ok(res);
        }
    }
}
