using System.Text.Json.Serialization;

namespace TrainManagementSystem.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public List<User> Users { get; set; } = new();
}