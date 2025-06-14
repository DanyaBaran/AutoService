using AutoService.Shared.Models;
using AuthService.Api.Services;
using Microsoft.AspNetCore.Mvc;

public record UpdateAdminStatusRequest(bool IsAdmin);

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        var users = _userService.GetAllUsers().Select(u => new User
        {
            Id = u.Id,
            Name = u.Name,
            IsAdmin = u.IsAdmin
        });
        return Ok(users);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAdminStatus(int id, [FromBody] UpdateAdminStatusRequest request)
    {
        var existingUser = _userService.GetById(id);
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.IsAdmin = request.IsAdmin;

        _userService.UpdateUser(existingUser);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return NoContent();
    }
}