using Microsoft.AspNetCore.Mvc;
using UseCase.Request.CashFlow;
using UseCase.UseCases.Interfaces;

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
}