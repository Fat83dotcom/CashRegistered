using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;

namespace CashRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController(IExpenseUseCase expenseUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExpense(CreateExpenseRequest request)
    {
        await expenseUseCase.CreateExpense(request);
        return Created();
    }
}