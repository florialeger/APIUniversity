using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]

public class EnrollmentController : ControllerBase
{

    private readonly UniversityContext _context;

    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailedEnrollmentDTO>>> GetEnrollments()
    {
        var enrollments = _context.Enrollments.Select(x => new DetailedEnrollmentDTO(x));
        return await enrollments.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollment(int id)
    {
        var enrollments = await _context.Enrollments
                                        .Include(s => s.Student)
                                        .Include(c => c.Course)
                                        .SingleOrDefaultAsync(t => t.Id == id);
        if (enrollments == null)
        {
            return NotFound();
        }

        return new DetailedEnrollmentDTO(enrollments);
    }

    // POST: api/enrollment
    [HttpPost]
    public async Task<ActionResult<DetailedEnrollmentDTO>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new Enrollment(enrollmentDTO);

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        enrollment.Course = await _context.Courses.FirstAsync(c => c.Id == enrollment.CourseId);
        enrollment.Student = await _context.Students.FirstAsync(c => c.Id == enrollment.StudentId);

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, new DetailedEnrollmentDTO(enrollment));
    }
}
