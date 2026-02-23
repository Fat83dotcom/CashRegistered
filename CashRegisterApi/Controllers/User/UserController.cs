using Microsoft.AspNetCore.Mvc;
using UseCase.Request.User;
using UseCase.UseCases.Interfaces;

namespace CashRegister.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController(ICreateUserUseCase userUseCase) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        userUseCase.CreateUser(request);
        return Created();
    }
}