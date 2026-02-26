using Microsoft.AspNetCore.Mvc;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserUseCase user) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        await user.CreateUser(request);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var result = await user.GetAllUsers();
        return Ok(result);
    }
}