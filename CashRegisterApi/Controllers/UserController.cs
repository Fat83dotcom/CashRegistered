using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserUseCase user) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var response = await user.CreateUser(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var result = await user.GetAllUsers();
        return Ok(result);
    }

    [HttpPut("Disable")]
    public async Task<IActionResult> DisableUser([FromQuery] int userId)
    {
        await user.DisableUser(userId);
        return Ok();
    }
}