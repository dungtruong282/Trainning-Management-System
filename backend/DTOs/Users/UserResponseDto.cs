namespace TrainManagementSystem.DTOs.Users;

public class UserResponseDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string Role { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}