using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EduAPI.Entities;
using EduAPI.Services;

namespace EduAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorsController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: api/instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetAll()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        // GET: api/instructors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> Get(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null) return NotFound();
            return Ok(instructor);
        }

        // POST: api/instructors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Instructor instructor)
        {
            await _instructorService.AddInstructorAsync(instructor);
            return CreatedAtAction(nameof(Get), new { id = instructor.InstructorID }, instructor);
        }

        // PUT: api/instructors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Instructor instructor)
        {
            if (id != instructor.InstructorID) return BadRequest();
            await _instructorService.UpdateInstructorAsync(instructor);
            return NoContent();
        }

        // DELETE: api/instructors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorService.DeleteInstructorAsync(id);
            return NoContent();
        }
    }
}
