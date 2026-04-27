using Application.Inventory.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Inventory.Request;

namespace CashRegister.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
public class UnitOfMeasureController(
    IUnitOfMeasureUseCase unitOfMeasureUseCase
) : ControllerBase
{
    [HttpPost]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> CreateUnitOfMeasure(CreateUnitOfMeasureRequest request)
    {
        var response = await unitOfMeasureUseCase.CreateUnitOfMeasure(request);
        return Ok(response);
    }

    [HttpGet("search")]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> SearchUnits([FromQuery] SearchUnitOfMeasureRequest request)
    {
        var response = await unitOfMeasureUseCase.SearchUnits(request);
        return Ok(response);
    }
}