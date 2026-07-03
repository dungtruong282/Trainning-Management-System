namespace TrainManagementSystem.DTOs.Users;

public class CreateUserDto
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string Role { get; set; } = "Employee";

    public string Status { get; set; } = "Active";

    public int DepartmentId { get; set; }

    public bool IsActive { get; set; } = true;
}