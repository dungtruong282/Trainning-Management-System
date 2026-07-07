using Microsoft.EntityFrameworkCore;
using TrainManagementSystem.Data;
using TrainManagementSystem.DTOs.Courses;
using TrainManagementSystem.Models;
using TrainManagementSystem.Services.Interfaces;

namespace TrainManagementSystem.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _context;

    public CourseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseResponseDto>> GetAllAsync()
    {
        return await _context.Courses
            .Include(c => c.CreatedByUser)
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CreatedAt = c.CreatedAt,
                CreatedByUserId = c.CreatedByUserId,
                CreatedByUserName = c.CreatedByUser != null ? c.CreatedByUser.FullName : null
            })
            .ToListAsync();
    }

    public async Task<CourseResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .Include(c => c.CreatedByUser)
            .Where(c => c.Id == id)
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                CreatedAt = c.CreatedAt,
                CreatedByUserId = c.CreatedByUserId,
                CreatedByUserName = c.CreatedByUser != null ? c.CreatedByUser.FullName : null
            })
            .FirstOrDefaultAsync();
    }

    public async Task<CourseResponseDto> CreateAsync(CreateCourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Description = dto.Description,
            CreatedByUserId = dto.CreatedByUserId,
            CreatedAt = DateTime.Now
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var user = await _context.Users.FindAsync(course.CreatedByUserId);

        return new CourseResponseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            CreatedAt = course.CreatedAt,
            CreatedByUserId = course.CreatedByUserId,
            CreatedByUserName = user?.FullName
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateCourseDto dto)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return false;
        }

        course.Title = dto.Title;
        course.Description = dto.Description;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return false;
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return true;
    }
}