using Microsoft.EntityFrameworkCore;
using TrainManagementSystem.Data;
using TrainManagementSystem.DTOs.Users;
using TrainManagementSystem.Models;
using TrainManagementSystem.Services.Interfaces;

namespace TrainManagementSystem.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserResponseDto>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Department)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role,
                Status = u.Status,
                DepartmentId = u.DepartmentId,
                DepartmentName = u.Department != null ? u.Department.Name : null,
                CreatedAt = u.CreatedAt,
                IsActive = u.IsActive
            })
            .ToListAsync();
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Department)
            .Where(u => u.Id == id)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role,
                Status = u.Status,
                DepartmentId = u.DepartmentId,
                DepartmentName = u.Department != null ? u.Department.Name : null,
                CreatedAt = u.CreatedAt,
                IsActive = u.IsActive
            })
            .FirstOrDefaultAsync();
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = dto.PasswordHash,
            Phone = dto.Phone,
            Role = dto.Role,
            Status = dto.Status,
            DepartmentId = dto.DepartmentId,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.Now
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var department = await _context.Departments.FindAsync(user.DepartmentId);

        return new UserResponseDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Phone,
            Role = user.Role,
            Status = user.Status,
            DepartmentId = user.DepartmentId,
            DepartmentName = department?.Name,
            CreatedAt = user.CreatedAt,
            IsActive = user.IsActive
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.Phone = dto.Phone;
        user.Role = dto.Role;
        user.Status = dto.Status;
        user.DepartmentId = dto.DepartmentId;
        user.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}