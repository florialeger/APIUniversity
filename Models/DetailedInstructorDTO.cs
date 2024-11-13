namespace ApiUniversity.Models;

public class DetailedInstructorDTO
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public List<Course> Courses { get; set; } = new();
    public List<Department> AdministeredDepartments { get; set; } = new();

    public DetailedInstructorDTO() { }

    public DetailedInstructorDTO(Instructor instructor)
    {
        Id = instructor.Id;
        LastName = instructor.LastName;
        FirstName = instructor.FirstName;
        HireDate = instructor.HireDate;
        Courses = instructor.Courses;
        AdministeredDepartments = instructor.AdministeredDepartments;
    }


}