using TrainManagementSystem.DTOs.Courses;

namespace TrainManagementSystem.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseResponseDto>> GetAllAsync();

    Task<CourseResponseDto?> GetByIdAsync(int id);

    Task<CourseResponseDto> CreateAsync(CreateCourseDto dto);

    Task<bool> UpdateAsync(int id, UpdateCourseDto dto);

    Task<bool> DeleteAsync(int id);
}