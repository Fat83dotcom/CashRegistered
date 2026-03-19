using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ILoginAppService loginService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await loginService.Login(request);
        if (token.Length <= 0) return Unauthorized();
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/",
            Expires = DateTime.UtcNow.AddHours(2)
        };

        Response.Cookies.Append("access_token", token, cookieOptions);
        
        return Ok();
    }
    
    [HttpGet("verify")]
    [Authorize]
    public IActionResult Verify()
    {
        return Ok(); 
    }
}