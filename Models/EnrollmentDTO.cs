namespace ApiUniversity.Models;

public class EnrollmentDTO
{
    public int Id { get; set; }
    public Grade Grade { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public EnrollmentDTO() { }
    public EnrollmentDTO(Enrollment enrollment)
    {
        StudentId = enrollment.StudentId;
        CourseId = enrollment.CourseId;
        Id = enrollment.Id;
        Grade = enrollment.Grade;
    }
}