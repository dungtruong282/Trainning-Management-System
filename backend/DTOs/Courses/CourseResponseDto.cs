namespace TrainManagementSystem.DTOs.Courses;

public class CourseResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }

    public string? CreatedByUserName { get; set; }
}