using Application.Inventory.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Inventory.Request;

namespace CashRegister.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(
    ICategoryUseCase categoryUseCase    
) : ControllerBase
{
    [HttpPost]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var response = await categoryUseCase.CreateCategory(request);
        return Ok(response);
    }
    
    [HttpGet("search")]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> GetSearchCategory([FromQuery] SearchCategoryRequest request)
    {
        var response = await categoryUseCase.GetSearchCategories(request);
        return Ok(response);
    }

    [HttpPut("{id}/deactivate")]
    [Authorize(Policy = "LogisticsOnly")]
    public async Task<IActionResult> DeactivateCategory([FromRoute] int id)
    {
        await categoryUseCase.DeactivateCategory(id);
        return Ok();
    }
}