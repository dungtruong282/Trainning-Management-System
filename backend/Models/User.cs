namespace TrainManagementSystem.Models;

public class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string Role { get; set; } = "Employee";

    public string Status { get; set; } = "Active";

    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}