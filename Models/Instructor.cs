namespace ApiUniversity.Models;

public class Instructor
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public List<Course> Courses { get; set; } = new();
    public List<Department> AdminiteredDepartments { get; set; } = new();

    public Instructor() {}


}