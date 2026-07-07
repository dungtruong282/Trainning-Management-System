namespace TrainManagementSystem.Models;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int CreatedByUserId { get; set; }

    public User? CreatedByUser { get; set; }
}