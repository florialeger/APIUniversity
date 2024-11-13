namespace ApiUniversity.Models;

public class Instructor
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public List<Course> Courses { get; set; } = new();
    public List<Department> AdministeredDepartments { get; set; } = new();

    public Instructor() {}

    public Instructor(InstructorDTO instructorDTO) {
        Id = instructorDTO.Id;
        LastName = instructorDTO.LastName;
        FirstName = instructorDTO.FirstName;
    }

    
    public Instructor(DetailedInstructorDTO detailedinstructorDTO) {
        Id = detailedinstructorDTO.Id;
        LastName = detailedinstructorDTO.LastName;
        FirstName = detailedinstructorDTO.FirstName;
        HireDate = detailedinstructorDTO.HireDate;
        Courses = detailedinstructorDTO.Courses;
        AdministeredDepartments = detailedinstructorDTO.AdministeredDepartments;
    }


}