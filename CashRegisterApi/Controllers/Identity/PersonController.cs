using Application.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Identity.Request;

namespace CashRegister.Controllers.Identity;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IPersonUseCase personUseCase) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
    {
        var response = await personUseCase.CreatePerson(request);
        return Ok(response);
    }

    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetAll()
    {
        // Agora seguindo rigorosamente o fluxo de Use Case
        var people = await personUseCase.GetAllPeople();
        var result = people.Select(p => new {
            p.Id,
            p.Name,
            p.Document
        });
        return Ok(result);
    }

    [HttpGet("email/{email}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var person = await personUseCase.GetPersonByEmail(email);
        return Ok(person);
    }

    [HttpGet("document/{document}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetByDocument(string document)
    {
        var person = await personUseCase.GetPersonByDocument(document);
        return Ok(person);
    }
}
