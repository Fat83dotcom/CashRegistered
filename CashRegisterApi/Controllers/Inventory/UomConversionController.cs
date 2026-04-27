using Application.Inventory.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Inventory.Request;

namespace CashRegister.Controllers.Inventory;

[Route("api/[controller]")]
[ApiController]
public class UomConversionController(
    IUomConversionUseCase uomConversionCase    
) : ControllerBase
{
    [HttpPost]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> CreateUomConversion(
        [FromBody] CreateUomConversionRequest request
    )
    {
        var response = await uomConversionCase.CreateUomConversion(request);
        return Ok(response);
    }

    [HttpGet("Search")]
    [Authorize (Policy = "LogisticsOnly")]
    public async Task<IActionResult> SearchUomConversion(
        [FromQuery] SearchUomConversionRequest request
    )
    {
        var response = await uomConversionCase.SearchUomConversion(request);
        return Ok(response);
    }
}