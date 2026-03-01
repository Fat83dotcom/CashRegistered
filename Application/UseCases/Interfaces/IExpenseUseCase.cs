using Shared.Request;

namespace Application.UseCases.Interfaces;

public interface IExpenseUseCase
{
    public Task CreateExpense(CreateExpenseRequest request);
}