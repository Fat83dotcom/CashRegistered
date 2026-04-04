using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserUseCase user) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var response = await user.CreateUser(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await user.GetAllUsers();
        return Ok(result);
    }

    [HttpPut("Disable")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DisableUser([FromQuery] int userId)
    {
        await user.DisableUser(userId);
        return Ok();
    }

    [HttpPut("ChangePassword")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userIdString = User.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (!int.TryParse(userIdString, out int userId))
        {
            return Unauthorized();
        }

        await user.ChangePassword(userId, request);
        return Ok();
    }
}
