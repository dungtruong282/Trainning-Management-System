namespace TrainManagementSystem.DTOs.Courses;

public class CreateCourseDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int CreatedByUserId { get; set; }
}