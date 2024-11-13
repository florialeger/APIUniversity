namespace ApiUniversity.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new();
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<Instructor> Instructors { get; set; } = new();


    public Course() { }

    public Course(CourseDTO courseDTO)
    {
        Id = courseDTO.Id;
        Title = courseDTO.Title;
        Credits = courseDTO.Credits;
        DepartmentId = courseDTO.DepartmentId;
        Department = courseDTO.Department;
        Instructors = courseDTO.Instructors;
    }
}