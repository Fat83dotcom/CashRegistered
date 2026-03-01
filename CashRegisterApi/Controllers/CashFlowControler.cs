using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CashFlowController(ICashFlowUseCase cashFlow) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCashFlow([FromBody] CreateCashFlowRequest request)
    {
        await cashFlow.CreateCashFlow(request);
        return Created();
    }

    [HttpGet("CashFlowAvailable")]
    public async Task<IActionResult> GetCashFlowsAvailable()
    {
        var response = await cashFlow.GetCashFlowsAvailable();
        return Ok(response);
    }

    [HttpGet("GetExpensesByCashFlowIdId/")]
    public async Task<IActionResult> GetExpensesByCashFlowId([FromQuery] int cashFlowId)
    {
        var response = await cashFlow.GetExpensesByCashFlowId(cashFlowId);
        return Ok(response);
    }
}