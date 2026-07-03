using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainManagementSystem.DTOs.Users;
using TrainManagementSystem.Services.Interfaces;

namespace TrainManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponseDto>>> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create(CreateUserDto dto)
    {
        var created = await _userService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto dto)
    {
        var result = await _userService.UpdateAsync(id, dto);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.DeleteAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}