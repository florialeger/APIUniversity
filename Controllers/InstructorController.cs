using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;


[ApiController]
[Route("api/instructor")]

public class InstructorController : ControllerBase
{
    private readonly UniversityContext _context;
    
    public InstructorController(UniversityContext context)
    {
        _context = context;
    }

      // GET: api/instructor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailedInstructorDTO>>> GetInstructors()
    {
        // Get students and related lists
        var instructors = _context.Instructors;
        return await instructors.Select(x => new DetailedInstructorDTO(x)).ToListAsync();
    }



     // GET: api/student
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedInstructorDTO>> GetInstructor(int id)
    {
        var instructor = await _context.Instructors
                                        .Include(c => c.Courses)
                                        .Include(d => d.AdministeredDepartments)
                                        .SingleOrDefaultAsync(t => t.Id == id);

        if (instructor == null)
            return NotFound();

        return new DetailedInstructorDTO(instructor);
    }


    // POST: api/instructor
    [HttpPost]
    public async Task<ActionResult<InstructorDTO>> PostInstructor(InstructorDTO instructorDTO)
    {
        Instructor instructor = new(instructorDTO);

        _context.Instructors.Add(instructor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, instructor);
    }


    //   // POST: api/instructor
    // [HttpPost]
    // public async Task<ActionResult<DetailedinstructorDTO>> PostInstructor(int id)
    // {
    //     Instructor instructor = new(instructorDTO);

    //     _context.Instructors.Add(instructor);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, instructor);
    // }
}