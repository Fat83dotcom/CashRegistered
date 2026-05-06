using Application.Inventory.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Inventory.Request;

namespace CashRegister.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
public class TagController(ITagUseCase tagUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTage([FromBody] CreateTagRequest request)
    {
        var response = await tagUseCase.CreateTag(request);
        return Ok(response);
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchTags([FromQuery] SearchTagRequest request)
    {
        var response = await tagUseCase.SearchTags(request);
        return Ok(response);
    }
}