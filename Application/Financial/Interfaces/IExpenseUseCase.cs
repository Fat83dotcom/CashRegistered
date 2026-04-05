using Shared.Financial.Request;

namespace Application.Financial.Interfaces;

public interface IExpenseUseCase
{
    public Task CreateExpense(CreateExpenseRequest request);
}