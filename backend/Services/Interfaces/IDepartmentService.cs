using TrainManagementSystem.DTOs.Departments;

namespace TrainManagementSystem.Services.Interfaces;

public interface IDepartmentService
{
    Task<List<DepartmentResponseDto>> GetAllAsync();

    Task<DepartmentResponseDto?> GetByIdAsync(int id);

    Task<DepartmentResponseDto> CreateAsync(CreateDepartmentDto dto);

    Task<bool> UpdateAsync(int id, UpdateDepartmentDto dto);

    Task<bool> DeleteAsync(int id);
}