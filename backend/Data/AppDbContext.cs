using Microsoft.EntityFrameworkCore;
using TrainManagementSystem.Models;

namespace TrainManagementSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Course> Courses { get; set; }
}