using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace CashRegister.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController(ICreateUserUseCase createUser, IGetUserUseCase getUser) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        await createUser.CreateUser(request);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var result = await getUser.GetUsers();
        return Ok(result);
    }
}